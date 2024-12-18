using CoffeeShopWEBAPI.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShopWEBAPI.Data
{
    public class StateRepository
    {
        private readonly string _connectionString;

        public StateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<StateModel> SelectAll()
        {
            var states = new List<StateModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    states.Add(new StateModel
                    {
                        StateID = Convert.ToInt32(reader["StateID"]),
                        StateName = reader["StateName"].ToString(),
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        StateCode = reader["StateCode"].ToString()
                    });
                }
            }
            return states;
        }

        public StateModel SelectByPK(int stateID)
        {
            StateModel state = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@StateID", stateID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    state = new StateModel
                    {
                        StateID = Convert.ToInt32(reader["StateID"]),
                        StateName = reader["StateName"].ToString(),
                        CountryID = Convert.ToInt32(reader["CountryID"]),
                        StateCode = reader["StateCode"].ToString()
                    };
                }
            }
            return state;
        }

        public bool Insert(StateModel state)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@CountryID", state.CountryID);
                cmd.Parameters.AddWithValue("@StateCode", state.StateCode);

                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }

        public bool Update(StateModel state)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@StateID", state.StateID);
                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@CountryID", state.CountryID);
                cmd.Parameters.AddWithValue("@StateCode", state.StateCode);

                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }

        public bool Delete(int stateID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_LOC_State_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@StateID", stateID);

                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }
    }
}
