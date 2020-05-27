using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace IT_services
{
    class MyClassLib
    {



    }


    public class DatabaseHandler
    {
        public SqlConnection conn;
        public DatabaseHandler()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\ПППІ\Лаб.раб\Лаб.раб№7\IT_services\IT_services\DatabaseHandler.mdf;Integrated Security=True");
                //conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:не подключена база данных! ");
            }
        }

        protected void openDB()
        {
            conn.Open();
        }
        protected void closeDB()
        {
            conn.Close();
        }



    }


    public class User : DatabaseHandler
    {
        public String Name, emailUser, password, telephon;
        public List<string[]> spisok_ser = new List<string[]>();

            public string vuvod()
        {
            return emailUser;
        }
        public bool registration(string email, string password, string name, string phone)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE email = @em", conn))
            {
                command.Parameters.AddWithValue("@em", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Console.Write("\nError! Электронная почта уже зарегистрирована\n");
                    ///Console.Read();
                    reader.Close();
                    closeDB();
                    return false;
                }
                else
                {
                    closeDB();
                    openDB();
                    string sqlExpression = String.Format("INSERT INTO [User] (email,password,name, telephon) VALUES (N'{0}', N'{1}',N'{2}', N'{3}')", email, password, name, phone);
                    using (SqlCommand command_1 = new SqlCommand(sqlExpression, conn))
                    {
                        //Console.WriteLine("Регистрация прошла успешно!");
                        Name = name;
                        emailUser = email;
                        telephon = phone;
                        command_1.ExecuteNonQuery();
                        closeDB();
                    }
                }
            }
            return true;
        }
        public bool authorisation(string email, string password)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE email = @em AND password = @pass", conn))
            {
                command.Parameters.AddWithValue("@em", email);
                command.Parameters.AddWithValue("@pass", password);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    Name = reader[2].ToString();
                    emailUser = email;
                    telephon= reader[3].ToString();
                    //Console.Clear();
                    //Console.Write(Name + "\nАвторизация прошла успешно");
                    closeDB();
                    return true;
                }
                else {  closeDB();}
            }         
            return false;
        }

        public DataTable readCustomer(string id)
        {
            List<string[]> spisok_customer = new List<string[]>();
            DataTable dt = new DataTable();
            openDB();
            string sql = "SELECT [Customer].nameCustomer, [Order].phoneCustomer, [Order].emailCustomer, [Order].date, [Order].status FROM [Order] JOIN [Customer] on [Customer].emailCustomer=[Order].emailCustomer WHERE [Order].IdServise=@id";
            using (SqlCommand comm = new SqlCommand(sql, conn))

            {
                comm.Parameters.AddWithValue("@id", id);
                SqlDataReader reader_1 = comm.ExecuteReader();

                if (reader_1.HasRows) // если есть данные
                {
                   // int k = 0;
                    while (reader_1.Read())
                    {
                        // k++;
                        spisok_customer.Add(new string[4]);
                        spisok_customer[spisok_customer.Count - 1][0] = reader_1[0].ToString();
                        spisok_customer[spisok_customer.Count - 1][1] = reader_1[1].ToString();
                        spisok_customer[spisok_customer.Count - 1][2] = reader_1[2].ToString();
                        spisok_customer[spisok_customer.Count - 1][3] = reader_1[3].ToString();
                        ///Console.WriteLine(reader_1[0].ToString() + "  " + reader_1[1].ToString());
                    }

                    reader_1.Close();
                    var dataAdapter = new SqlDataAdapter(comm);
                    dataAdapter.Fill(dt);
                    closeDB();
                    return dt;
                }
                else { closeDB(); return new DataTable(); }
            }                    
        }



        public DataTable readServise()
        {
            //openDB();
            spisok_ser.Clear();
            // spisok_ser.Clear();
            DataTable dt = new DataTable();
            openDB();
            string sqlExpression = "SELECT id, name,start,konets,city,price,phone,decription FROM [Servise] WHERE emailUser='"+emailUser+"'";
            using (SqlCommand command = new SqlCommand(sqlExpression, conn))
            {                             
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    //int i = 0;
                    while (reader.Read())
                    {

                        spisok_ser.Add(new string[8]);
                        spisok_ser[spisok_ser.Count - 1][0] = reader[0].ToString();
                        spisok_ser[spisok_ser.Count - 1][1] = reader[1].ToString();
                        spisok_ser[spisok_ser.Count - 1][2] = reader[2].ToString();
                        spisok_ser[spisok_ser.Count - 1][3] = reader[3].ToString();
                        spisok_ser[spisok_ser.Count - 1][4] = reader[4].ToString();
                        spisok_ser[spisok_ser.Count - 1][5] = reader[5].ToString();
                        spisok_ser[spisok_ser.Count - 1][6] = reader[6].ToString();
                        spisok_ser[spisok_ser.Count - 1][7] = reader[7].ToString();


                    }
                    reader.Close();
                    var dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dt);
                    closeDB();
                    return dt;

                }
                else { closeDB();  return new DataTable(); }
             // reader.Close();
            }
            
        
            
        }

        public void deleteServise(string nomer)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("DELETE [Servise] WHERE Id=@id", conn))
            {                
                command.Parameters.AddWithValue("@id", nomer);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Заказ удален!");
                reader.Close();
            }
            closeDB();
        }

        public void updateStatus(string id, string email, string status)
        {
            /*string status;
            if (nomer == 1) { status = "Подтвержден"; } else status = "Выполнен";
            */
           /* Console.WriteLine(id);
            Console.WriteLine(email);
            Console.WriteLine(status);*/

            openDB();
            using (SqlCommand command = new SqlCommand("UPDATE [Order] SET status=@status WHERE IdServise=@id and emailCustomer = @email", conn))
            {
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = command.ExecuteReader();
             //   Console.WriteLine("Статус изменен!");
                reader.Close();
            }
            closeDB();

        }



        public void add_servise(servise ser)
        {
            closeDB();
            openDB();
            string sqlExpression = String.Format("INSERT INTO [Servise] (emailUser,name, start, konets, city, price,phone,decription) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}','{5}',N'{6}',N'{7}')", emailUser,ser.name_servise,ser.start,ser.konets,ser.city,ser.price,ser.phone,ser.description);
            using (SqlCommand command = new SqlCommand(sqlExpression, conn))
            {
               
                command.ExecuteNonQuery();
                Console.WriteLine("Услуга успешно добавлена!");               
                closeDB();
            }
        }
    }

    public class servise: DatabaseHandler {
        public String name_servise;
        public String start;
        public String konets;
        public String city;
        public float price;
        public String phone;
        public String description;




    }



    public class Customer : DatabaseHandler
    {
        public String NameCustomer, emailCustomer, telephonCustomer;
       // public List<string[]> spisok_ser=new List<string[]>();
        //public List<string[]> spisok_order = new List<string[]>();
        public bool authorisation(string email, string password)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("SELECT * FROM [Customer] WHERE emailCustomer = @em AND passwordCustomer = @pass", conn))
            {
                command.Parameters.AddWithValue("@em", email);
                command.Parameters.AddWithValue("@pass", password);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    NameCustomer = reader[2].ToString();
                    telephonCustomer = reader[3].ToString();
                    emailCustomer = email;
                  //  Console.Clear();
                 ///   Console.Write(NameCustomer + "\nАвторизация прошла успешно\n");
                    closeDB();
                    return true;
                }
                else
                {
                    //Console.Write("Error! Неправильный логин или пароль!\n");
                    closeDB();
                }
            }
            return false;
        }



        public bool registration(string email, string password, string name, string telephon)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("SELECT * FROM [Customer] WHERE emailCustomer = @em", conn))
            {
                command.Parameters.AddWithValue("@em", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.Write("\nError! Электронная почта уже зарегистрирована\n");
                    Console.Read();
                    reader.Close();
                    closeDB();
                    return false;
                }
                else
                {
                    closeDB();
                    openDB();
                    string sqlExpression = String.Format("INSERT INTO [Customer] (emailCustomer,passwordCustomer,nameCustomer, phoneCustomer) VALUES (N'{0}', N'{1}',N'{2}', N'{3}')", email, password, name, telephon);
                    using (SqlCommand command_1 = new SqlCommand(sqlExpression, conn))
                    {
                        Console.WriteLine("Регистрация прошла успешно!");
                        NameCustomer = name;
                        emailCustomer = email;
                        telephonCustomer = telephon;
                        command_1.ExecuteNonQuery();
                        closeDB();
                    }
                }
            }
            return true;
        }

        public DataTable poiskServise(string servis)
        {
           List<string[]> spisok_ser = new List<string[]>();
            DataTable dt = new DataTable();
      // spisok_ser.Clear();
            openDB();
            using (SqlCommand command = new SqlCommand("SELECT [Servise].id, [Servise].name, [Servise].start, [Servise].konets, [Servise].city," +
                "[Servise].price, [User].name, [Servise].phone, [Servise].decription" +
                " FROM [Servise] JOIN [User] on [Servise].emailUser=[User].email WHERE [Servise].name=@ser", conn))


            //using (SqlCommand command = new SqlCommand("SELECT * FROM [Servise] JOIN [User] on [Servise].emailUser=[User].email where [Servise].name=+'" + servis.ToString() + "'", conn))
            {
                command.Parameters.AddWithValue("@ser", servis);
                //where [Servise].name=+'"+servis+"'
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                       /* i++;
                        Console.WriteLine(i + "  " + reader[1].ToString());
                        Console.WriteLine("Период доступности:");
                        Console.WriteLine("От: " + reader[2].ToString());
                        Console.WriteLine("До: " + reader[3].ToString());
                        Console.WriteLine("Город: " + reader[4].ToString());
                        Console.WriteLine("Стоимость услуги: " + reader[5].ToString());
                        Console.WriteLine("Имя исполнителя: " + reader[6].ToString());
                        Console.WriteLine("Телефон: " + reader[7].ToString());
                        Console.WriteLine("Описание услуги: " + reader[8].ToString());
                        Console.WriteLine();*/
                        spisok_ser.Add(new string[9]);
                        spisok_ser[spisok_ser.Count-1][0]= reader[0].ToString();
                        spisok_ser[spisok_ser.Count - 1][1] = reader[1].ToString();
                        spisok_ser[spisok_ser.Count - 1][2] = reader[2].ToString();
                        spisok_ser[spisok_ser.Count - 1][3] = reader[3].ToString();
                        spisok_ser[spisok_ser.Count - 1][4] = reader[4].ToString();
                        spisok_ser[spisok_ser.Count - 1][5] = reader[5].ToString();
                        spisok_ser[spisok_ser.Count - 1][6] = reader[6].ToString();
                        spisok_ser[spisok_ser.Count - 1][7] = reader[7].ToString();
                        spisok_ser[spisok_ser.Count - 1][8] = reader[8].ToString();
                        

                    }

                    reader.Close();
                    var dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dt);
                    closeDB();
                    return dt;
                }
                else
                {
                     closeDB(); return new DataTable(); 
                }
               
               
            }

            

        }

        public DataTable filterPrice(string otPrice, string doPrice, DataTable table)
        {   //List < string[]> spisok_ser= new List<string[]>();
           // spisok_ser = spisok_s;
            float priceOt=0;
            float.TryParse(otPrice, out priceOt);
            float priceDo = 0;           
            float.TryParse(doPrice, out priceDo);
            List<string[]> spisok = new List<string[]>();
            //int k = 0;
            DataTable dt = new DataTable();
            /* for(int i=0; i<spisok_ser.Count(); i++)
              {   
                  if(float.Parse(spisok_ser[i][5])>=priceOt && float.Parse(spisok_ser[i][5]) <= priceDo)
                  {
                     /* k++;
                      Console.WriteLine(k + "  " + spisok_ser[i][1]);
                      Console.WriteLine("Период доступности:");
                      Console.WriteLine("От: " + spisok_ser[i][2]);
                      Console.WriteLine("До: " + spisok_ser[i][3]);
                      Console.WriteLine("Город: " + spisok_ser[i][4]);
                      Console.WriteLine("Стоимость услуги: " + spisok_ser[i][5]);
                      Console.WriteLine("Имя исполнителя: " + spisok_ser[i][6]);
                      Console.WriteLine("Телефон: " + spisok_ser[i][7]);
                      Console.WriteLine("Описание услуги: " + spisok_ser[i][8]);
                      Console.WriteLine();*/
            /*        spisok.Add(new string[9]);
                    spisok[spisok.Count - 1][0] = spisok_ser[i][0];
                    spisok[spisok.Count - 1][1] = spisok_ser[i][1];
                    spisok[spisok.Count - 1][2] = spisok_ser[i][2];
                    spisok[spisok.Count - 1][3] = spisok_ser[i][3];
                    spisok[spisok.Count - 1][4] = spisok_ser[i][4];
                    spisok[spisok.Count - 1][5] = spisok_ser[i][5];
                    spisok[spisok.Count - 1][6] = spisok_ser[i][6];
                    spisok[spisok.Count - 1][7] = spisok_ser[i][7];
                    spisok[spisok.Count - 1][8] = spisok_ser[i][8];
                }
            }*/
            /* for (int i=0; i<table.Rows.Count; i++)
             {
                 if (float.Parse(table.Rows[i][5].ToString()) >= priceOt && float.Parse(table.Rows[i][5].ToString()) <= priceDo)
                 {
                     DataRow row =table.Rows[i];
                     Console.WriteLine(row);
                     //dt.Rows.Add(table.Rows[i]);
                     dt.ImportRow(table.Rows[i]);
                 }

             }*/
            for (int i = 0; i < 9; i++) 
            dt.Columns.Add();
            dt.Columns["Column1"].ColumnName = "id";
            dt.Columns["Column2"].ColumnName = "name";
            dt.Columns["Column3"].ColumnName = "start";
            dt.Columns["Column4"].ColumnName = "konets";
            dt.Columns["Column5"].ColumnName = "city";
            dt.Columns["Column6"].ColumnName = "price";
            dt.Columns["Column7"].ColumnName = "name1";
            dt.Columns["Column8"].ColumnName = "phone";
            dt.Columns["Column9"].ColumnName = "decription";


            foreach (DataRow row in table.Rows)
            {
                // получаем все ячейки строки
                if (float.Parse(row[5].ToString()) >= priceOt && float.Parse(row[5].ToString()) <= priceDo)
                {
                    var cells = row.ItemArray;
                    dt.Rows.Add(cells);
                   /* foreach (object cell in cells)
                        Console.Write(cell);
                    Console.WriteLine();*/
                }
            }
            // Console.WriteLine(dt.Rows[0].ItemArray.ToString());

            /*spisok_ser.Clear();
            spisok_ser = spisok.GetRange(0, spisok.Count);*/

            /* for (int i = 0; i < spisok_ser.Count(); i++)
             { Console.WriteLine(spisok_ser[i][2]);
                 Console.Read();
             }*/
            

            return dt;

        }

        public DataTable filterDate(string Date, DataTable table)
        {
           // List<string[]> spisok = new List<string[]>();
            DataTable dt = new DataTable();
            DateTime date = DateTime.ParseExact(Date, "dd.MM.yyyy", System.Globalization.CultureInfo.InstalledUICulture);
            //  int k = 0;
            /* for (int i = 0; i < spisok_ser.Count(); i++)
             {             
                     if(DateTime.ParseExact(spisok_ser[i][2], "dd.MM.yyyy", System.Globalization.CultureInfo.InstalledUICulture) <= date &&
                     DateTime.ParseExact(spisok_ser[i][3], "dd.MM.yyyy", System.Globalization.CultureInfo.InstalledUICulture) >= date)
                 {
                   /*  k++;
                     Console.WriteLine(k + "  " + spisok_ser[i][1]);
                     Console.WriteLine("Период доступности:");
                     Console.WriteLine("От: " + spisok_ser[i][2]);
                     Console.WriteLine("До: " + spisok_ser[i][3]);
                     Console.WriteLine("Город: " + spisok_ser[i][4]);
                     Console.WriteLine("Стоимость услуги: " + spisok_ser[i][5]);
                     Console.WriteLine("Имя исполнителя: " + spisok_ser[i][6]);
                     Console.WriteLine("Телефон: " + spisok_ser[i][7]);
                     Console.WriteLine("Описание услуги: " + spisok_ser[i][8]);
                     Console.WriteLine();*/
            /*    spisok.Add(new string[9]);
                spisok[spisok.Count - 1][0] = spisok_ser[i][0];
                spisok[spisok.Count - 1][1] = spisok_ser[i][1];
                spisok[spisok.Count - 1][2] = spisok_ser[i][2];
                spisok[spisok.Count - 1][3] = spisok_ser[i][3];
                spisok[spisok.Count - 1][4] = spisok_ser[i][4];
                spisok[spisok.Count - 1][5] = spisok_ser[i][5];
                spisok[spisok.Count - 1][6] = spisok_ser[i][6];
                spisok[spisok.Count - 1][7] = spisok_ser[i][7];
                spisok[spisok.Count - 1][8] = spisok_ser[i][8];
            }
        }
        /*   spisok_ser.Clear();
           spisok_ser = spisok.GetRange(0, spisok.Count);*/
            for (int i = 0; i < 9; i++)
                dt.Columns.Add();
            dt.Columns["Column1"].ColumnName = "id";
            dt.Columns["Column2"].ColumnName = "name";
            dt.Columns["Column3"].ColumnName = "start";
            dt.Columns["Column4"].ColumnName = "konets";
            dt.Columns["Column5"].ColumnName = "city";
            dt.Columns["Column6"].ColumnName = "price";
            dt.Columns["Column7"].ColumnName = "name1";
            dt.Columns["Column8"].ColumnName = "phone";
            dt.Columns["Column9"].ColumnName = "decription";

            foreach (DataRow row in table.Rows)
            {
                // получаем все ячейки строки
                if (DateTime.ParseExact(row[2].ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InstalledUICulture) <= date &&
                     DateTime.ParseExact(row[3].ToString(), "dd.MM.yyyy", System.Globalization.CultureInfo.InstalledUICulture) >= date)
                {
                    var cells = row.ItemArray;
                    dt.Rows.Add(cells);
                    /* foreach (object cell in cells)
                         Console.Write(cell);
                     Console.WriteLine();*/
                }
            }
            return dt;
        }

        public DataTable  filterCity(string city, DataTable table)
        {
            //List<string[]> spisok = new List<string[]>();
            //int k = 0;
            DataTable dt = new DataTable();
            /*  for (int i = 0; i < spisok_ser.Count(); i++)
              {
                  if (spisok_ser[i][4] == city)
                  {
                    /*  k++;
                      Console.WriteLine(k + "  " + spisok_ser[i][1]);
                      Console.WriteLine("Период доступности:");
                      Console.WriteLine("От: " + spisok_ser[i][2]);
                      Console.WriteLine("До: " + spisok_ser[i][3]);
                      Console.WriteLine("Город: " + spisok_ser[i][4]);
                      Console.WriteLine("Стоимость услуги: " + spisok_ser[i][5]);
                      Console.WriteLine("Имя исполнителя: " + spisok_ser[i][6]);
                      Console.WriteLine("Телефон: " + spisok_ser[i][7]);
                      Console.WriteLine("Описание услуги: " + spisok_ser[i][8]);
                      Console.WriteLine();*/
            /*   spisok.Add(new string[9]);
               spisok[spisok.Count - 1][0] = spisok_ser[i][0];
               spisok[spisok.Count - 1][1] = spisok_ser[i][1];
               spisok[spisok.Count - 1][2] = spisok_ser[i][2];
               spisok[spisok.Count - 1][3] = spisok_ser[i][3];
               spisok[spisok.Count - 1][4] = spisok_ser[i][4];
               spisok[spisok.Count - 1][5] = spisok_ser[i][5];
               spisok[spisok.Count - 1][6] = spisok_ser[i][6];
               spisok[spisok.Count - 1][7] = spisok_ser[i][7];
               spisok[spisok.Count - 1][8] = spisok_ser[i][8];
           }
       }
       /*spisok_ser.Clear();
       spisok_ser = spisok.GetRange(0, spisok.Count);*/
            for (int i = 0; i < 9; i++)
                dt.Columns.Add();
            dt.Columns["Column1"].ColumnName = "id";
            dt.Columns["Column2"].ColumnName = "name";
            dt.Columns["Column3"].ColumnName = "start";
            dt.Columns["Column4"].ColumnName = "konets";
            dt.Columns["Column5"].ColumnName = "city";
            dt.Columns["Column6"].ColumnName = "price";
            dt.Columns["Column7"].ColumnName = "name1";
            dt.Columns["Column8"].ColumnName = "phone";
            dt.Columns["Column9"].ColumnName = "decription";

            foreach (DataRow row in table.Rows)
            {
                // получаем все ячейки строки
                if (row[4].ToString() == city)
                {
                    var cells = row.ItemArray;
                    dt.Rows.Add(cells);
                    /* foreach (object cell in cells)
                         Console.Write(cell);
                     Console.WriteLine();*/
                }
            }
            return dt;
        }

        public void serviceOrder(string id_servise)
        {
            string status = "В обработке";
           
            //int i = nomer-1;
            /*Console.WriteLine(spisok_ser[i][0]);
            Console.WriteLine( "  " + spisok_ser[i][1]);
            Console.WriteLine("Период доступности:");
            Console.WriteLine("От: " + spisok_ser[i][2]);
            Console.WriteLine("До: " + spisok_ser[i][3]);
            Console.WriteLine("Город: " + spisok_ser[i][4]);
            Console.WriteLine("Стоимость услуги: " + spisok_ser[i][5]);
            Console.WriteLine("Имя исполнителя: " + spisok_ser[i][6]);
            Console.WriteLine("Телефон: " + spisok_ser[i][7]);
            Console.WriteLine("Описание услуги: " + spisok_ser[i][8]);
            Console.WriteLine(NameCustomer);*/
           openDB();
            string sqlExpression = String.Format("INSERT INTO [Order] (IdServise,emailCustomer,phoneCustomer, status,date) VALUES (N'{0}', N'{1}',N'{2}',N'{3}',N'{4}')", id_servise, emailCustomer, telephonCustomer,status, DateTime.Now.ToString("dd.MM.yyyy"));
            using (SqlCommand command_1 = new SqlCommand(sqlExpression, conn))
            {
                Console.WriteLine("Услуга заказана!");
                
                command_1.ExecuteNonQuery();
            }
            closeDB();

        } 

        public DataTable readOrder()
        {
            
            List<string[]> spisok_order = new List<string[]>();
            DataTable dt = new DataTable();
             openDB();        
            using (SqlCommand command = new SqlCommand("SELECT  [Servise].id,  [Servise].name, [Servise].start, [Servise].konets, [Servise].city," +
                "[Servise].price, [User].name, [Servise].phone, [Servise].decription, [Order].status, [Order].date FROM [Servise] JOIN [Order] on [Servise].id=[Order].IdServise JOIN [User] on [User].email=[Servise].emailUser WHERE [Order].emailCustomer = @email", conn))


            {
                command.Parameters.AddWithValue("@email", emailCustomer);
                //where [Servise].name=+'"+servis+"'
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                   // int i = 0;
                   /* while (reader.Read())
                    {
                     
                        spisok_order.Add(new string[10]);
                        spisok_order[spisok_order.Count - 1][0] = reader[0].ToString();
                        spisok_order[spisok_order.Count - 1][1] = reader[1].ToString();
                        spisok_order[spisok_order.Count - 1][2] = reader[2].ToString();
                        spisok_order[spisok_order.Count - 1][3] = reader[3].ToString();
                        spisok_order[spisok_order.Count - 1][4] = reader[4].ToString();
                        spisok_order[spisok_order.Count - 1][5] = reader[5].ToString();
                        spisok_order[spisok_order.Count - 1][6] = reader[6].ToString();
                        spisok_order[spisok_order.Count - 1][7] = reader[7].ToString();
                        spisok_order[spisok_order.Count - 1][8] = reader[8].ToString();
                        spisok_order[spisok_order.Count - 1][9] = reader[9].ToString();


                    }
                    */
                    reader.Close();
                    var dataAdapter = new SqlDataAdapter(command);

                    dataAdapter.Fill(dt);
                    closeDB();
                    return dt;
                }
                else
                {
                    reader.Close();
                    closeDB(); return new DataTable();
                    //Console.WriteLine("Список заказов пуст");
                }
                /*reader.Close();
                closeDB();
                return spisok_order;*/
            }



        }
        public void Delete(string Order)
        {
            openDB();
            using (SqlCommand command = new SqlCommand("DELETE [Order] WHERE IdServise=@id and emailCustomer = @email", conn))
            {
                Console.WriteLine("Заказ удален!");
                command.Parameters.AddWithValue("@id", Order);
                command.Parameters.AddWithValue("@email", emailCustomer);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            closeDB();
        }




    }

    }