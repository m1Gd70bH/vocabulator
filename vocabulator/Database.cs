using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Vocabulator
{
    /// <summary>
    /// database class dor db i/o
    /// </summary>
    class Database
    {
        static SQLiteConnection connection;

        public Database()
        {
            //to do: check online database
            try
            {      
                if (connection == null) //set path (local)
                {
                    connection = new SQLiteConnection("Data Source=vtrainerdb.sqlite;Version=3;");
                }
                if (connection != null && connection.State != ConnectionState.Open) //open db
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT date('now');", connection);   //test command
                    command.Prepare();
                    SQLiteDataReader reader = command.ExecuteReader();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Cant load database or database not found!\n Errordetails: " + e.ToString(),
                   "Vocabulator Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// enter new user into db (check username before!)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public void RegisterUser(string name, string password, bool isAdmin)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "INSERT INTO users (name, password, is_admin) " + 
                    "VALUES (@name, @password, @is_admin)";
                command.Prepare();
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("password", SHA256.Hash(password));
                command.Parameters.AddWithValue("is_admin", isAdmin);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// check if username and pw correct
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidLogin(string name, string password)
        {
            bool isvalid = false;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT name FROM users WHERE name=@name AND password=@password";
                command.Prepare();
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("password", SHA256.Hash(password));
                try
                {
                    isvalid = command.ExecuteReader().HasRows;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return isvalid;
            }
        }

        /// <summary>
        /// check if username allrdy taken (case sensitive)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UserExists(string name)
        {
            bool exist = false;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT name FROM users WHERE name=@name";
                command.Prepare();
                command.Parameters.AddWithValue("name", name);
                try
                {
                    exist = command.ExecuteReader().HasRows;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return exist;
        }

        /// <summary>
        /// check if user is admin //poor but working
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool CheckRights (string name)
        {
            bool isadmin = false;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT is_admin FROM users WHERE name=@name";
                command.Parameters.AddWithValue("name", name);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        isadmin = reader.GetBoolean(0);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return isadmin;
        }

        /// <summary>
        /// get user-id by username
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int getuserid(string user)
        {
            int userid=0;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT id FROM users WHERE name=@user";
                command.Parameters.AddWithValue("user", user);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            userid = reader.GetInt16(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return userid;
        }
        
        /// <summary>
        /// get username by user-id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string getusername(int userid)
        {
            string user = "" ;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT name FROM users WHERE id=@userid";
                command.Parameters.AddWithValue("userid", userid);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())                 
                        if (reader.Read())
                            user = reader.GetString(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }       
            }
            return user;
        }

        /// <summary>
        /// get group-id by groupname
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public int getgroupid(string groupname)
        {
            int groupid = 0;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT id FROM groups WHERE title=@groupname";
                command.Parameters.AddWithValue("groupname", groupname);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            groupid = reader.GetInt16(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return groupid;
        }
        /// <summary>
        /// get unit-id by name
        /// </summary>
        /// <param name="lessonname"></param>
        /// <returns></returns>
        public int getunitid(string unitname)
        {
            int unitid = 0;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT id FROM units WHERE title=@unitname";
                command.Parameters.AddWithValue("unitname", unitname);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            unitid = reader.GetInt16(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return unitid;
        }

        /// <summary>
        /// get unitname by unit-id
        /// </summary>
        /// <param name="lessonid"></param>
        /// <returns></returns>
        public string getunitname(int lessonid)
        {
            string unitname = "";
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT title FROM units WHERE id=@lessonid";
                command.Parameters.AddWithValue("lessonid", lessonid);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())                    
                        if (reader.Read())
                            unitname = reader.GetString(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return unitname;
        }

        /// <summary>
        /// get groupname by groupid
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public string getgroupname(int groupid)
        {
            string groupname = "";
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT title FROM groups WHERE id=@groupid";
                command.Parameters.AddWithValue("groupid", groupid);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            groupname = reader.GetString(0);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return groupname;
        }

        /// <summary>
        /// give a lsit of known themes from db
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public List<string> getunits()
        {
            string unit="";
            List<string> units = new List<string>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT title FROM units";
                command.Parameters.AddWithValue("title", unit);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            unit = reader.GetString(0);
                            units.Add(unit);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return units;
        }

        /// <summary>
        /// give a list of knwon groups from db
        /// </summary>
        /// <param name="unitid"></param>
        /// <returns></returns>
        public List<string> getgroups(int unitid)
        {
            string group = "";
            List<string> groups = new List<string>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT title FROM groups WHERE unit_id=@unitid";
                command.Parameters.AddWithValue("unitid", unitid);
                command.Parameters.AddWithValue("title", group );
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            group = reader.GetString(0);
                            groups.Add(group);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return groups;
        }

        /// <summary>
        /// read knwon vocabs from db into list by groupid and userId
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Vocab> GetVocabs(int groupId, int userId)
        {
            var vocabs = new List<Vocab>();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT id, english, german, picture_path, sound_path FROM vocabulary " + 
                    "WHERE group_id=@group_id";
                command.Parameters.AddWithValue("group_id", groupId);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vocab = new Vocab();
                            vocab.id = reader.GetInt32(0);
                            vocab.english = reader.GetString(1);
                            vocab.german = reader.GetString(2);
                            vocab.picturepath = reader.GetValue(3).ToString();
                            vocab.soundpath = reader.GetValue(4).ToString();
                            vocab.level = GetVocabLevel(vocab.id, userId);
                            vocabs.Add(vocab);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return vocabs;
        }

        /// <summary>
        /// get vocabs by known level
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userId"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public List<Vocab> GetVocabsByLevel(int groupId, int userId, int level)
        {
            var vocabs = GetVocabs(groupId, userId);
            var filteredVocabs = vocabs;
            if (vocabs.Count == 1)
                filteredVocabs = vocabs; 
            else filteredVocabs = vocabs.Where(x => x.level == level).ToList<Vocab>();
            return filteredVocabs;
        }

        /// <summary>
        /// get vocablevel by userid
        /// </summary>
        /// <param name="vocabId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetVocabLevel(int vocabId, int userId)
        {
            int level = 0;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT level FROM progress WHERE user_id = @user_id AND vocab_id = @vocab_id";
                command.Parameters.AddWithValue("vocab_id", vocabId);
                command.Parameters.AddWithValue("user_id", userId);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            level = reader.GetInt32(0);
                    }
                }
                catch (Exception ex)
                {
                    level = 0;
                    throw new Exception(ex.Message);
                }
            }
            return level;
        }

        /// <summary>
        /// get user progress from db
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public List<int> GetProgress(int userId, int groupId)
        {
            List<int> progress = new List<int>();
            int vocabId = 0;
            int level = 0;
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT vocab_id, level FROM progress WHERE userid=@userid AND group_id=@groupid";
                command.Prepare();
                command.Parameters.AddWithValue("vocab_id", vocabId);
                command.Parameters.AddWithValue("level", level);
                command.Parameters.AddWithValue("group_id", groupId);
                command.Parameters.AddWithValue("userid", userId);
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vocabId = reader.GetInt32(0);
                            level = reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            progress.Add(vocabId);
            progress.Add(level);
            return progress;
        }

        /// <summary>
        /// set user progress in db
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public void SetProgress(int userId, int vocabId, int level)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE progress SET level = @level WHERE user_id = @user_id AND vocab_id = @vocab_id";
                command.Prepare();
                command.Parameters.AddWithValue("user_id", userId);
                command.Parameters.AddWithValue("vocab_id", vocabId);
                command.Parameters.AddWithValue("level", level);
                int affected = command.ExecuteNonQuery();
                if (affected == 0)
                {
                    command.CommandText = "INSERT INTO progress (user_id, vocab_id, level) " +
                        "VALUES (@user_id, @vocab_id, @level)";
                    command.Prepare();
                    command.Parameters.AddWithValue("user_id", userId);
                    command.Parameters.AddWithValue("vocab_id", vocabId);
                    command.Parameters.AddWithValue("level", level);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        internal void DeleteSound(Vocab vocab)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE vocabulary SET sound_path = @sound_path WHERE id = @id";
                command.Prepare();
                command.Parameters.AddWithValue("sound_path", null);
                command.Parameters.AddWithValue("id", vocab.id);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// get filepath from known sound
        /// </summary>
        /// <param name="vocabid"></param>
        /// <returns></returns>
        internal string GetSoundPathByVocabId(int vocabid)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                string soundpath = "";
                command.CommandText = "SELECT sound_path FROM vocabulary WHERE id=@id";
                command.Parameters.AddWithValue("id", vocabid);
                command.Parameters.AddWithValue("sound_path", soundpath);
                command.Prepare();
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// set sound path in db
        /// </summary>
        /// <param name="vocabid"></param>
        /// <param name="picture_path"></param>
        public void SetSoundPath(int vocabid, string sound_path)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE vocabulary SET sound_path = @sound_path WHERE id = @id";
                command.Prepare();
                command.Parameters.AddWithValue("sound_path", sound_path);
                command.Parameters.AddWithValue("id", vocabid);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// set picture path in db
        /// </summary>
        /// <param name="vocabid"></param>
        /// <param name="picture_path"></param>
        public void SetPicturePath(int vocabid, string picture_path)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE vocabulary SET picture_path = @picture_path WHERE id = @id";
                command.Prepare();
                command.Parameters.AddWithValue("picture_path", picture_path);
                command.Parameters.AddWithValue("id",vocabid);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        internal void DeleteVocab(int vocabid)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM vocabulary WHERE id = @id";
                command.Prepare();
                command.Parameters.AddWithValue("id", vocabid);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// delete a known vocab
        /// </summary>
        /// <param name="vocab"></param>
        public void DeletePicture(Vocab vocab)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "UPDATE vocabulary SET picture_path = @picture_path WHERE id = @id";
                command.Prepare();
                command.Parameters.AddWithValue("picture_path", null);
                command.Parameters.AddWithValue("id", vocab.id);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Save a new Vocab into db.
        /// </summary>
        /// <param name="NewVocab"></param>
        /// <param name="groupid"></param>
        /// <param name="picture_path"></param>
        /// <param name="sound_path"></param>                
        public void SaveNewVocab(Vocab NewVocab, int groupid,string picture_path, string sound_path)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {   
                command.CommandText = "INSERT INTO vocabulary (group_id, english, german, english_accept, german_accept, example, picture_path, sound_path) "+
                    "VALUES (@group_id, @english, @german, @english_accept, @german_accept, @example, @picture_path, @sound_path)";
                command.Prepare();
                command.Parameters.AddWithValue("group_id", groupid);
                command.Parameters.AddWithValue("english", NewVocab.english);
                command.Parameters.AddWithValue("german", NewVocab.german);
                command.Parameters.AddWithValue("english_accept", NewVocab.english_accept);
                command.Parameters.AddWithValue("german_accept", NewVocab.german_accept);
                command.Parameters.AddWithValue("example", NewVocab.example);
                command.Parameters.AddWithValue("picture_path", picture_path);
                command.Parameters.AddWithValue("sound_path", sound_path);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        
        /// <summary>
        /// get the filepath to known picture file
        /// </summary>
        /// <param name="vocabid"></param>
        /// <returns></returns>
        public string GetPicturePathByVocabId(int vocabid)
        {
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                string picturepath="";
                command.CommandText = "SELECT picture_path FROM vocabulary WHERE id=@id";
                command.Parameters.AddWithValue("id", vocabid);
                command.Parameters.AddWithValue("picture_path", picturepath);
                command.Prepare();
                try
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        return reader.GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
