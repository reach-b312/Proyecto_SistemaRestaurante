using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic; //Para las listas
using System.Data.Common; //Para trabajar la conexion al motor

namespace restaurantExpress.Data
{
    public class DbHelper
    {
        //propiedades
        private string _ConnectionString = "";
        //conector
        private DbConnection _Connection;
        //stored procedure
        private DbCommand _Command;
        //instancia la conexion a db
        private DbProviderFactory _factory = null;
        private DbProviders _provider;
        //propiedad commandtext usar 4 para stored procedures
        private CommandType _Commandtype;

        #region
        //getters & setters
        public string ConnectionString { get => _ConnectionString; set => _ConnectionString = value; }
        public DbConnection Connection { get => _Connection; set => _Connection = value; }
        public DbCommand Command { get => _Command; set => _Command = value; }
        public DbProviderFactory Factory { get => _factory; set => _factory = value; }
        public DbProviders Provider { get => _provider; set => _provider = value; }
        public CommandType Commandtype { get => _Commandtype; set => _Commandtype = value; }
        #endregion

        //constructor, definiciones para stored procedures
        public DbHelper(string ConnectString, CommandType CommandType, DbProviders ProviderName = DbHelper.DbProviders.MySQL)
        {
            _provider = ProviderName;
            _Commandtype = CommandType;
            _factory = MySqlClientFactory.Instance;
            Connection = _factory.CreateConnection();
            Connection.ConnectionString = ConnectString;
            Command = _factory.CreateCommand();
            //crea la conexion
            Command.Connection = Connection;
        }

        #region
        //Control de transacciones:
        //Integridad de la base de datos
        private void BeginTransaccion() 
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            Command.Transaction = Connection.BeginTransaction();
        }

        private void CommitTransaction()
        {
            if(Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Commit();
                Connection.Close();
            }
        }
        //Consistencia de la base de datos
        private void RollbackTransaction()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Rollback();
                Connection.Close();
            }
        }
        #endregion

        public int CRUD(string query)
        {
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            int i = -1;
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                BeginTransaccion();
                i = Command.ExecuteNonQuery();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                //Log
            }
            finally //Liberar recursos
            {
                Command.Parameters.Clear();
                Connection.Dispose();
                Command.Dispose();
            }
            return i;
        }
        
        public DataTable GetDataTable(string query)
        {
            DbDataAdapter adapter = _factory.CreateDataAdapter();
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch(Exception ex)
            {
                //Logs
                //trow;
            }
            finally
            {
                Command.Parameters.Clear();
                if(Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }
            return ds.Tables[0];
        }

        public int AddParameters(string name, object value)
        {
            DbParameter parm = _factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;
            return Command.Parameters.Add(parm);
        }


        //prov. disponibles
        public enum DbProviders
        {
            MySQL, SQLServer, Oracle, OleDb, SQLite
        }
    }
    
}
