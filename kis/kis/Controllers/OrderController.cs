using kis.DB_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kis.Controllers
{
    public class OrderController
    {
        private int cur_user_id {  get; set; }
        private VidContext db {  get; set; }

        public OrderController(VidContext db, int id) 
        {
            cur_user_id = id;
            this.db = db;
        }
        public string[,] Get_All_Orders(DateTime date1, DateTime date2)
        {
            DateOnly from_date = new DateOnly(date1.Year, date1.Month, date1.Day);
            DateOnly to_date = new DateOnly(date2.Year, date2.Month, date2.Day);

            List<CardOrder> cardOrders = new List<CardOrder>();
            List<Order> orders = db.Orders.ToList();
            for (int i = orders.Count - 1; i >= 0; i--)
            {
                if (!(from_date <= orders[i].OrderDate && orders[i].OrderDate <= to_date))
                {
                    orders.RemoveAt(i);
                }
            }

            string[,] table = new string[orders.Count, 3];
            for (int i = 0; i < orders.Count; i++)
            {
                int? sum = 0;
                List<CardOrder> cur_Orders = db.CardOrders.Where(co => co.OrderId == orders[i].OrderId).ToList();
                table[i, 0] = orders[i].OrderDate.ToString();
                table[i, 1] = cur_Orders.Count.ToString();
                for (int j = 0; j < cur_Orders.Count; j++)
                {
                    int? cur_cost = db.Cards.FirstOrDefault(c => c.CardId == cur_Orders[j].CardId).CardPrice;
                    sum += cur_cost;
                }
                table[i, 2] = sum.ToString();
            }
            return table;
        }

        public string[,] Get_Orders()
        {
            List<Shipment> shipments = db.Shipments.Where(s => s.UserId == cur_user_id).ToList();
            List<List<Order>> orders_list = new List<List<Order>>();
            List<List<CardOrder>> cards_list = new List<List<CardOrder>>();
            foreach (var shipment in shipments)
            {
                int? sh_id = shipment.ShipmentId;
                orders_list.Add(db.Orders.Where(o => o.ShipmentId == sh_id).ToList());
            }
            List<Order> orders = orders_list.SelectMany(list => list).ToList();
            foreach (var order in orders)
            {
                cards_list.Add(db.CardOrders.Where(co => co.OrderId == order.OrderId).ToList());
            }
            List<CardOrder> cards = cards_list.SelectMany(list => list).ToList();
            string[,] table = new string[cards.Count, 5];
            int? temp_order = -1;
            int? temp_card = -1;
            int card_num = 1;
            int first_card_id = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (cards[i].OrderId != temp_order)
                {
                    table[i, 0] = cards[i].OrderId.ToString();
                    table[i, 1] = db.Orders.FirstOrDefault(o => o.OrderId == cards[i].OrderId).OrderDate.ToString();
                    int? sh_id =  db.Orders.FirstOrDefault(o => o.OrderId == cards[i].OrderId).ShipmentId;
                    table[i, 4] = db.Shipments.FirstOrDefault(s => s.ShipmentId == sh_id).ShipmentDate.ToString();
                    temp_order = cards[i].OrderId;
                }
                if (cards[i].CardId == temp_card)
                {
                    if (card_num == 1)
                    {
                        first_card_id = i - 1; 
                    }
                    card_num += 1;
                    if (i == table.GetLength(0) - 1)
                    {
                        var cur_card = db.Cards.FirstOrDefault(c => c.CardId == cards[i].CardId);
                        if (cur_card != null)
                        {
                            table[first_card_id, 3] = card_num.ToString();
                        }
                    }
                }
                else
                {
                    var cur_card = db.Cards.FirstOrDefault(c => c.CardId == cards[i].CardId);
                    if( cur_card != null)
                    {
                        table[i, 2] = db.Manufacturers.FirstOrDefault(m => m.ManufacturerId == cur_card.CategoryId).ManufacturerName[0] + " " + db.Types.FirstOrDefault(t => t.TypeId == cur_card.TypeId).TypeName[0] + " " + cur_card.Gpu + " " + cur_card.CardGpuName[0];
                        table[first_card_id, 3] = card_num.ToString();
                    }
                    card_num = 1;
                    temp_card = cards[i].CardId;
                    first_card_id = i;
                }
            }
            return remove_spaces_from_table(table);
        }
        public string[,] remove_spaces_from_table(string[,] array)
        {
            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            // Создаем новый список для хранения строк с непустыми элементами
            List<string[]> nonEmptyRows = new List<string[]>();

            // Проходим по каждой строке массива
            for (int i = 0; i < rowCount; i++)
            {
                bool isEmptyRow = true;
                for (int j = 0; j < colCount; j++)
                {
                    if (array[i, j] != null)
                    {
                        isEmptyRow = false;
                        break;
                    }
                }
                if (!isEmptyRow)
                {
                    string[] row = new string[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        row[j] = array[i, j];
                    }
                    nonEmptyRows.Add(row);
                }
            }
            string[,] newArray = new string[nonEmptyRows.Count, colCount];
            for (int i = 0; i < nonEmptyRows.Count; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    newArray[i, j] = nonEmptyRows[i][j];
                }
            }
            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for(int j = 0;j < newArray.GetLength(1); j++)
                {
                    if (newArray[i,j] == null)
                    {
                        newArray[i,j] = "";
                    }
                }
            }
            return newArray;
        }
    }
}
