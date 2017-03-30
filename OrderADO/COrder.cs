using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace OrderADO
{

    static class CreateStr  // 
    {
        public readonly static string CreateOrderStr =
                        "(" +
                        "[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY," +           // uniqueidentifier
                        "[NDock] NVARCHAR(20) NOT NULL," +                             // Номер документа
                        "[Summ] REAL NOT NULL," +                                      // Сумма заказа
                        "[Status] INT NOT NULL," +                                     // Status заказа

                        // Эти поля для того чтобы не удалять заказ в случае удаления или изменения типа заказа                     
                        "[NameType] NVARCHAR(30) NOT NULL," +                          // Наименование Типа Заказа
                        "[Perc] REAL NOT NULL," +                                      // Процент

                        "[Comment] NVARCHAR(250) NOT NULL);";                          // Коментарий

        public readonly static string CreateTypeOrderStr =
                        "(" +
                        "[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY," +           // uniqueidentifier
                        "[Name] NVARCHAR(30) NOT NULL," +                              // Имя типа заказа
                        "[Perc] REAL NOT NULL,"+                                       // Процент
                        "[Comment] NVARCHAR(250) NOT NULL);";                          // Коментарий

        public readonly static string CreateOrderPoleStr =
                        "(" +
                        "[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY," +           // uniqueidentifier
                        "[IdOrder] BIGINT NOT NULL," +                                 // Id заказа
                        "[Number] INT NOT NULL," +                                     // Порядковый номер поля

                        // Эти полe для того чтобы не удалять поля заказа в случае удаления или изменения типа заказа
                        "[NamePole] NVARCHAR(30) NOT NULL," +                          // Наименование поля
                        "[Text] NVARCHAR(100) NOT NULL,"+                              // значение поля
                        "CONSTRAINT FK_Order_OrderPole FOREIGN KEY (IdOrder) REFERENCES TableOrder(Id));";

        public readonly static string CreateTypeOrderPoleStr =
                        "(" +
                        "[Id] BIGINT NOT NULL IDENTITY (1,1) PRIMARY KEY," +           // uniqueidentifier
                        "[IdTypeOrder] BIGINT NOT NULL," +                             // Id заказа
                        "[Number] INT NOT NULL," +                                     // Порядковый номер поля
                        "[NamePole] NVARCHAR(30) NOT NULL," +                          // Наименование поля
                        "CONSTRAINT FK_TypeOrder_TypeOrderPole FOREIGN KEY (IdTypeOrder) REFERENCES TableTypeOrder(Id));";
    }


    public abstract class StructData
    {
        public StructData() { }
        public StructData(DataRow dr)
        {
            RowToThis(dr);
        }

        public abstract bool ThisToRow(DataRow dr);
        public abstract bool RowToThis(DataRow dr);
    }

    // Класс Заказа

    public class cOrder : StructData    
    {
        static string[] statusmas = new string[2] { "Не обработано", "Обработано" };

        int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string NuberDockument;
        public string NDock
        {
            get { return NuberDockument; }
            set { NuberDockument = value; }
        }

        decimal summ;
        public decimal Summ
        {
            get { return summ; }
            set { summ = value; }
        }

        int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public string StatusStr
        {
            get
            {
                return statusmas[status];
            }
        }

        string nameTypeOrder;
        public string NameTypeOrder
        {
            get { return nameTypeOrder; }
            set { nameTypeOrder = value; }
        }

        decimal percent;
        public decimal Percent
        {
            get { return percent; }
            set { percent = value; }
        }

        string comment;
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public List<cOrderPole> ListPole;

        public cOrder(int id, string nuberdockument, decimal summ, int status, string nametypeorder, decimal percent,string comment)
            :base()
        {

            SetOrder(id, nuberdockument, summ, status, nametypeorder, percent, comment);
            ListPole = new List<cOrderPole>();
        }
        public cOrder()
            : base()
        {
            SetOrder(-1, "", 0, 0, "", 0, "");
            ListPole = new List<cOrderPole>();            
        }

        public cOrder(DataRow dr):base(dr)
        { }

        public void SetOrder(int id, string nuberdockument, decimal summ, int status, string nametypeorder, decimal percent, string comment)
        {
            Id = id;
            NuberDockument = nuberdockument;
            Summ = summ;
            Status = status;
            NameTypeOrder = nametypeorder;
            Percent = percent;
            Comment = comment;
        }


        public override bool RowToThis(DataRow dr)
        {
            bool ret = false;

            try
            {
                /*
                Id = -1;       Int32.TryParse(dr[0].ToString(), out id);                
                             NuberDockument = dr[1].ToString();
                Summ = 0;    Decimal.TryParse(dr[2].ToString(), out summ);
                Status = 0;    Int32.TryParse(dr[3].ToString(), out status);
                              NameTypeOrder = dr[4].ToString();
                Percent = 0; Decimal.TryParse(dr[5].ToString(), out percent);
                                    Comment = dr[6].ToString();
                */
                
                                    Id = (int)dr.Field<long>(0);
                           NuberDockument = dr.Field<string>(1);
                             Summ = (decimal)dr.Field<float>(2);
                                      Status = dr.Field<int>(3);
                            NameTypeOrder = dr.Field<string>(4);
                          Percent = (decimal)dr.Field<float>(5);
                                  Comment = dr.Field<string>(6);               

                                    ret = true;
            }
            catch { }
            return ret;
        }

        public override bool ThisToRow(DataRow dr)
        {
            bool ret = false;
            try
            {
                dr[1] = NuberDockument;
                dr[2] = Summ;
                dr[3] = Status;
                dr[4] = NameTypeOrder;
                dr[5] = Percent;
                dr[6] = Comment;
                ret = true;
            }
            catch { }
            return ret;
        }

    }

    // Класс дополнительных полей Заказа
    public class cOrderPole : StructData    
    {
        public int Id;
        public int IdOrder;
        public int Number;
        public string NamePole;
        public string Text;
        public cOrderPole(int id, int idorder, int number, string namePole, string text)
        {
            SetOrderPole(id, idorder, number, namePole, text);
        }
        public cOrderPole()
        {
            SetOrderPole(-1, -1, -1, "", "");
        }

        public cOrderPole(DataRow dr)
            : base(dr)
        { }

        public void SetOrderPole(int id, int idorder, int number, string namePole, string text)
        {
            Id = id;
            IdOrder = idorder;
            Number = number;
            NamePole = namePole;
            Text = text;
        }

        public override bool RowToThis(DataRow dr)
        {
            bool ret = false;

            try
            {
                /*
                Id = -1;      Int32.TryParse(dr[0].ToString(), out Id);
                IdOrder = -1; Int32.TryParse(dr[1].ToString(), out IdOrder);
                 Number = -1; Int32.TryParse(dr[2].ToString(), out Number);
                                  NamePole = dr[3].ToString();
                                      Text = dr[4].ToString();
                 */
                   Id = (int)dr.Field<long>(0);
              IdOrder = (int)dr.Field<long>(1);
                     Number = dr.Field<int>(2);
                NamePole = dr.Field<string>(3);
                    Text = dr.Field<string>(4);

                ret = true;
            }
            catch { }
            return ret;
        }

        public override bool ThisToRow(DataRow dr)
        {
            bool ret = false;
            try
            {
                //dr[0] = 0;
                //dr[1] = 0;
                dr[2] = Number;
                dr[3] = NamePole;
                dr[4] = Text;
                ret = true;
            }
            catch { }
            return ret;
        }

    }

    // Класс Типов Заказа
    public class cTypeOrder : StructData    
    {
        public int Id;
        public string Name;
        public decimal Percent;
        public string Comment;
        public List<cTypeOrderPole> ListPole;
        public cTypeOrder(int id, string name, decimal percent, string comment)
        {
            SetTypeOrder(id, name, percent, Comment);
            ListPole = new List<cTypeOrderPole>();
        }
        public cTypeOrder()
        {
            SetTypeOrder(-1, "", 0, "");
            ListPole = new List<cTypeOrderPole>();
        }

        public cTypeOrder(DataRow dr)
            : base(dr)
        { }

        public void SetTypeOrder(int id, string name, decimal percent, string comment)
        {
            Id = id;
            Name = name;
            Percent = percent;
            Comment = comment;
        }
        public override string ToString()
        {
            return Name;
        }

        public override bool RowToThis(DataRow dr)
        {
            bool ret = false;

            try
            {
                /*
                Id = -1;       Int32.TryParse(dr[0].ToString(), out Id);
                                       Name = dr[1].ToString();
                Percent = 0; Decimal.TryParse(dr[2].ToString(), out Percent);
                                    Comment = dr[3].ToString();
                 */
                           Id = (int)dr.Field<long>(0);
                            Name = dr.Field<string>(1);
                 Percent = (decimal)dr.Field<float>(2);
                         Comment = dr.Field<string>(3);

                ret = true;
            }
            catch { }
            return ret;
        }

        public override bool ThisToRow(DataRow dr)
        {
            bool ret = false;
            try
            {
                dr[1] = Name;
                dr[2] = Percent;
                dr[3] = Comment;
                ret = true;
            }
            catch { }
            return ret;
        }
    }

    // Класс Полей Типов Заказа
    public class cTypeOrderPole : StructData    
    {
        public int Id;
        public int IdTypeOrder;
        public int Number;
        string namePole;
        public string NamePole
        {
            get { return namePole; }
            set { namePole = value; }
        }
        public cTypeOrderPole(int id, int idtypeorder, int number, string namepole)
        {
            SetTypeOrderPole(id, idtypeorder, number, namepole);
        }
        public cTypeOrderPole()
        {
            SetTypeOrderPole(-1, -1, -1, "");
        }

        public cTypeOrderPole(DataRow dr)
            : base(dr)
        { }


        public void SetTypeOrderPole(int id, int idtypeorder, int number, string namepole)
        {
            Id = id;
            IdTypeOrder = idtypeorder;
            Number = number;
            NamePole = namepole;
        }

        public override bool RowToThis(DataRow dr)
        {
            bool ret = false;

            try
            {
                /*
                Id = -1;          Int32.TryParse(dr[0].ToString(), out Id);
                IdTypeOrder = -1; Int32.TryParse(dr[1].ToString(), out IdTypeOrder);
                Number = -1;      Int32.TryParse(dr[2].ToString(), out Number);
                                      NamePole = dr[3].ToString();
                 */
                         Id = (int)dr.Field<long>(0);
                IdTypeOrder = (int)dr.Field<long>(1);
                           Number = dr.Field<int>(2);
                      NamePole = dr.Field<string>(3);

                ret = true;
            }
            catch { }
            return ret;
        }

        public override bool ThisToRow(DataRow dr)
        {
            bool ret = false;
            try
            {
                //dr[1] = Name;
                dr[2] = Number;
                dr[3] = NamePole;
                ret = true;
            }
            catch { }
            return ret;
        }
    }

}
