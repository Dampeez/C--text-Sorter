using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataTier;

namespace BusinessTier
{
   public class display
    {
        public static void Air()
        {
            string path = @"C:\Users\damia\Desktop\moe test\201571550_GradedExcersise2\airbnb_listings_cpt.input";
            var airData = ProcessInput(path);


            Console.WriteLine("AirBnB Response Rate Search");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Please enter in minimum response rate");
            string userRes = Console.ReadLine();

            if (userRes == "")
            {
                Console.WriteLine("Invalid Entry");
            }

            else
            {
                var responseRate = (from item in airData
                                    where item.host_response_rate == userRes
                                    select item);
                int count = responseRate.Count();


                string newPath = @"C:\Users\damia\Desktop\moe test\201571550_GradedExcersise2\airbnb_listings_cpt.txt";
                var output = new StringBuilder();

                foreach (var items in airData)
                {

                    var list = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}",
                        items.host_id,
                        items.host_response_rate,
                        items.host_is_superhost,
                        items.host_identity_verified,
                        items.property_type,
                        items.accommodates,
                        items.price,
                        items.review_scores_cleanliness
                        );

                    output.AppendLine(list);
                }
                System.IO.File.WriteAllText(newPath, output.ToString());
                Console.WriteLine("Total Matching reords: {0}", count);
                Console.WriteLine("Report Written to folder");

            }



        }

        public static List<Listings> ProcessInput(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Listings.ParseRow).ToList();
        }
    }
}
