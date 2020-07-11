using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
  public class Listings
    {
        public string id { get; set; }

        public string host_id { get; set; }

        public string host_response_rate { get; set; }

        public string host_is_superhost { get; set; }

        public string host_identity_verified { get; set; }

        public string property_type { get; set; }

        public string accommodates { get; set; }

        public string price { get; set; }

        public string review_scores_cleanliness { get; set; }


       public  static Listings ParseRow(string row)
        {

            var columns = row.Split(';');
            return new Listings()
            {
                id = columns[0],
                host_id = columns[1],

                host_response_rate = columns[6].Replace("%", ""),

                host_is_superhost = columns[7],

                host_identity_verified = columns[10],

                property_type = columns[19],

                accommodates = columns[21],

                review_scores_cleanliness = columns[35],




            };

        }
    }
}
