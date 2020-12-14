using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO_Driver
{
    class db_functions
    {
#if false
        public class player_8v8_record
        {
            public int uid { get; set; }
            public string nickname { get; set; }
            public int win { get; set; }
            public int loss { get; set; }
            public int death { get; set; }
            public decimal damage { get; set; }
            public decimal damage_taken { get; set; }
        }

        public void create_tables(SQLiteConnection sqlite_conn)
        {
            SQLiteCommand sqlite_cmd;

            string create_8v8_player_records = string.Format(@"DROP TABLE [player_records_8v8];CREATE TABLE [player_records_8v8] ([uid] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [nickname] text NOT NULL, [games] bigint NOT NULL, [wins] bigint NOT NULL, [losses] bigint NOT NULL, [deaths] bigint NOT NULL, [avg_damage] numeric(53,0) NOT NULL,[avg_damage_taken] numeric(53,0) NOT NULL);");

            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = create_8v8_player_records;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void record_8v8_player_record(SQLiteConnection sqlite_conn, player_8v8_record new_player)
        {

            SQLiteCommand existance_check = new SQLiteCommand(string.Format(@"SELECT count(*) FROM [player_records_8v8] WHERE uid = @uid"), sqlite_conn);
            existance_check.Parameters.AddWithValue("uid", new_player.uid);
            int player_exists = 0;

            try
            {
                player_exists = Convert.ToInt32(existance_check.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                existance_check.Dispose();
            }

            if (player_exists == 0)
            {
                SQLiteCommand insert_statment = new SQLiteCommand(string.Format(@"INSERT INTO [player_records_8v8] " +
                                                                                    "([uid],[nickname],[games],[wins],[losses],[deaths],[avg_damage],[avg_damage_taken]) " +
                                                                                "VALUES " +
                                                                                    "(@uid,@nickname,1,@win, @loss, @death, @avg_damage, @avg_damage_taken);"), sqlite_conn);
                insert_statment.Parameters.AddWithValue("uid", new_player.uid);
                insert_statment.Parameters.AddWithValue("nickname", new_player.nickname);
                insert_statment.Parameters.AddWithValue("win", new_player.win);
                insert_statment.Parameters.AddWithValue("loss", new_player.loss);
                insert_statment.Parameters.AddWithValue("death", new_player.death);
                insert_statment.Parameters.AddWithValue("avg_damage", new_player.damage);
                insert_statment.Parameters.AddWithValue("avg_damage_taken", new_player.damage_taken);

                try
                {
                    insert_statment.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    insert_statment.Dispose();
                }
            }
            else
            {
                SQLiteCommand update_statment = new SQLiteCommand(string.Format(@"UPDATE [player_records_8v8] " +
                                                                                    "SET [games] = [games] + 1 " +
                                                                                       ",[wins] = [wins] + @win " +
                                                                                       ",[losses] = [losses] + @loss " +
                                                                                       ",[deaths] = [deaths] + @death " +
                                                                                       ",[avg_damage] = [avg_damage] + @damage " +
                                                                                       ",[avg_damage_taken] = [avg_damage_taken] + @damage_taken " +
                                                                                       "WHERE [uid] = @uid;"), sqlite_conn);
                update_statment.Parameters.AddWithValue("win", new_player.win);
                update_statment.Parameters.AddWithValue("loss", new_player.loss);
                update_statment.Parameters.AddWithValue("death", new_player.death);
                update_statment.Parameters.AddWithValue("damage", new_player.damage);
                update_statment.Parameters.AddWithValue("damage_taken", new_player.damage_taken);
                update_statment.Parameters.AddWithValue("uid", new_player.uid);

                try
                {
                    update_statment.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    update_statment.Dispose();
                }
            }
        }
#endif
    }
}
