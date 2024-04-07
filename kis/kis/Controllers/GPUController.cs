using kis.DB_Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kis.Controllers
{
    public class GPUController
    {
        private VidContext db;
        private int cur_user_id {  get; set; }
        private List<string> ManufacturerList {  get; set; }
        private List<string> TypeList { get; set; }
        public GPUController(VidContext db, int id)
        {
            this.cur_user_id = id;
            this.db = db;
            TypeList = new List<string>();
            ManufacturerList = new List<string>();

        }
        public string[,] Get_GPUs()
        {
            string[,] table_content;
            table_content = new string[db.Cards.Count(), 10];
            foreach (var item in db.Cards)
            {
                table_content[item.CardId - 1, 0] = item.CardId.ToString();
                table_content[item.CardId - 1, 1] = item.CategoryId.ToString();
                table_content[item.CardId - 1, 2] = item.TypeId.ToString();
                table_content[item.CardId - 1, 3] = item.Gpu.ToString();
                table_content[item.CardId - 1, 4] = item.CardGpuName[0];
                table_content[item.CardId - 1, 5] = item.Ram.ToString();
                table_content[item.CardId - 1, 6] = item.CoolerNum.ToString();
                table_content[item.CardId - 1, 7] = item.CardPrice.ToString();
                table_content[item.CardId - 1, 8] = item.CardNum.ToString();
                table_content[item.CardId - 1, 9] = "0";
            }
            for (int i = 0; i < table_content.GetLength(0); i++)
            {
                int id;
                if (int.TryParse(table_content[i, 1], out id)) { }
                table_content[i, 1] = GetCategoryByID(id);
                if (int.TryParse(table_content[i, 2], out id)) { }
                table_content[i, 2] = GetTypeByID(id);
            }
            return table_content;
        }
        public string GetCategoryByID(int id)
        {
            return db.Manufacturers.FirstOrDefault(g => g.ManufacturerId == id).ManufacturerName[0].ToString();
        }
        public string GetTypeByID(int id)
        {
            return db.Types.FirstOrDefault(g => g.TypeId == id).TypeName[0].ToString();
        }
        public List<string> GetGpuVariants()
        {
            List<string> gpuVariants = new List<string>();
            foreach (var item in db.Cards)
            {
                string gpu = item.Gpu.ToString();
                if (!gpuVariants.Contains(gpu))
                {
                    gpuVariants.Add(gpu);
                }
            }
            return gpuVariants;
        }
        public List<string> GetRamVariants()
        {
            List<string> ramVariants = new List<string>();
            foreach (var item in db.Cards)
            {
                string ram = item.Ram.ToString();
                if (!ramVariants.Contains(ram))
                {
                    ramVariants.Add(ram);
                }
            }
            return ramVariants;
        }
        public List<string> GetCategoryVariants()
        {
            ManufacturerList.Clear();
            foreach (var item in db.Manufacturers)
            {
                ManufacturerList.Add(item.ManufacturerName[0].ToString());
            }
            return ManufacturerList;
        }
        public List<string> GetTypeVariants()
        {
            TypeList.Clear();
            foreach (var item in db.Types)
            {
                TypeList.Add(item.TypeName[0].ToString());
            }
            return TypeList;
        }
        public List<string> GetShopVariants()
        {
            List<string> shopVariants = new List<string>();
            foreach (var item in db.Shops)
            {
                string adres = item.ShopCity[0];
                if (!shopVariants.Contains(adres))
                {
                    shopVariants.Add(adres);
                }
            }
            return shopVariants;
        }
        public void SetManufacturer(int id, string[] manufacturer)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == id);
            var category = db.Manufacturers.FirstOrDefault(m => m.ManufacturerName == manufacturer.ToList());
            if (category == null) {
                var maxId = db.Manufacturers.Max(m => m.ManufacturerId);
                var newManufacturer = new Manufacturer
                {
                    ManufacturerId = maxId + 1,
                    ManufacturerName = manufacturer.ToList(),
                };
                db.Manufacturers.Add(newManufacturer);
                db.SaveChanges();
            }
            if (gpu != null && category != null)
            {
                gpu.CategoryId = category.ManufacturerId;
                db.SaveChanges();
            }
        }
        public void SetType(int id, string[] newtype)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == id);
            var type = db.Types.FirstOrDefault(t => t.TypeName == newtype.ToList());
            if (type == null)
            {
                var maxId = db.Types.Max(m => m.TypeId);
                var outtype = new DB_Classes.Type
                {
                    TypeId = maxId + 1,
                    TypeName = newtype.ToList(),
                };
                db.Types.Add(outtype);
                db.SaveChanges();
            }
            if (gpu != null && type != null)
            {
                gpu.TypeId = type.TypeId;
                db.SaveChanges();
            }
        }

        public void AddManufacturer(string[] manufacturer)
        {
            SetManufacturer(-1, manufacturer);
        }

        public void AddType(string[] type)
        {
            SetType(-1, type);
        }

        public void UpdateGPU(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                if (int.TryParse(value[0], out int gpu_num)) { }
                gpu.Gpu = gpu_num;
                db.SaveChanges();
            }
        }

        public void UpdateGPUName(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                gpu.CardGpuName = value.ToList();
                db.SaveChanges();
            }
        }

        public void UpdateRAM(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                if (int.TryParse(value[0], out int ram_num)) { }
                gpu.Ram = ram_num;
                db.SaveChanges();
            }
        }

        public void UpdateCoolerNum(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                if (int.TryParse(value[0], out int cool_num)) { }
                gpu.CoolerNum = cool_num;
                db.SaveChanges();
            }
        }

        public void UpdateCardNum(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                if (int.TryParse(value[0], out int card_num)) { }
                gpu.CardNum = card_num;
                db.SaveChanges();
            }
        }

        public void UpdateCardPrice(int gpuId, string[] value)
        {
            var gpu = db.Cards.FirstOrDefault(g => g.CardId == gpuId);
            if (gpu != null)
            {
                if (int.TryParse(value[0], out int price_num)) { }
                gpu.CardPrice = price_num;
                db.SaveChanges();
            }
        }

        public void OrderGPUs(int[] ids, int[] number)
        {
            int countO = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == -1)
                {
                    countO++;
                }
            }
            if (countO > 0)
            {
                DateTime currentDateTime = DateTime.Now;
                DateOnly currentDateOnly = new DateOnly(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day);
                Shipment shipment = new Shipment
                {
                    ShipmentId = db.Shipments.Max(m => m.ShipmentId) + 1,
                    UserId = cur_user_id,
                    ShipmentDate = currentDateOnly.AddDays(7),
                };
                Order order = new Order
                {
                    OrderId = db.Orders.Max(m => m.OrderId) + 1,
                    ShipmentId =shipment.ShipmentId,
                    OrderDate = currentDateOnly,
                };
                int cardOrderId = db.CardOrders.Max(m => m.CardOrderId);
                db.Shipments.Add(shipment);
                db.Orders.Add(order);
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != -1)
                    {
                        for (int j = 0; j < number[i]; j++)
                        {
                            cardOrderId += 1;
                            CardOrder cardOrder = new CardOrder
                            {
                                CardOrderId = cardOrderId,
                                OrderId = order.OrderId,
                                CardId = ids[i],
                            };
                            db.CardOrders.Add(cardOrder);
                        }
                        var gpu = db.Cards.FirstOrDefault(g => g.CardId == ids[i]);
                        if (gpu != null)
                        {
                            gpu.CardNum -= number[i];

                        }
                    }
                }
                db.SaveChanges();
            }
            
        }


    }
}
