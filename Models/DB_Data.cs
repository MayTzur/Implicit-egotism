using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ImplicitEgoizem.Models
{
    public class DB_Data
    {
        public DB_Data()
        {

        }

        public static DataTable GetDataSellers(string name)
        {
            DBServices db = new DBServices();
            return db.GetDataSellers(name);
        }

        static bool DiscountValue(string value)
        {
            return value == "Yes" ? true : false;            
        }

        public static void UpdateTable(DataTable changes_dt, string message_type)
        {
            DBServices db = new DBServices();
            DataTable dt = new DataTable();
            dt = db.GetDataSellers("");

            int id = 0;
           // bool discount_value;
            foreach (DataRow dr_changes in changes_dt.Rows)
            {
               // discount_value = DiscountValue(Convert.ToString(dr_changes["Discount_Status"]));
                id = Convert.ToInt32(dr_changes["ID"]);
                foreach (DataRow dr in dt.Rows)
                {
                    if (id == Convert.ToInt32(dr["ID"]))
                    {
                        if (message_type == "same_name")
                        {
                            dr["Contact_WithName"] = dr_changes["Checked"];
                            dr["Discount_with_name"] = dr_changes["Discount_Status"];
                            dr["sending_time_with"] = dr_changes["Time"];
                            dr["sending_date_with"] = dr_changes["Date"];                           
                            dr["Buyer_name"] = dr_changes["Name"];
                            dr["New_price_WithName"] = dr_changes["New_price"];
                        }
                        else if (message_type == "different_name")
                        {
                            dr["Contact_WithoutName"] = dr_changes["Checked"];
                            dr["Discount_without_name"] = dr_changes["Discount_Status"];
                            dr["sending_time_without"] = dr_changes["Time"];
                            dr["sending_date_without"] = dr_changes["Date"];
                            dr["New_price_WithoutName"] = dr_changes["New_price"];
                        }
                    }
                }
            }

            db.UpdateTable(dt);
        }
    }
}