using static assignment_oop_02.Program;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace assignment_oop_02
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region  Question 1
            // A -    What is the difference between a class and a struct?

            //  *  Class: Reference type, supports inheritance.

            //   * Struct: Value type, doesn't support inheritance

            //*******************************************************************************************
            //B - Why are classes more suitable than structs for large applications?

            //=>  Classes are better for large applications because they support inheritance, encapsulation, and polymorphism.

            #endregion

            #region  Question 2
            // A -Which class is the parent class?
            // Shipment is the parent 
            //  ***************************************
            // B -Which class is the child class?
            //  ExpressShipment is the chil
            //  ***********************************************
            //c-What members are inherited by ExpressShipment?
            //  TrackingCode
            // ************************************************
            // D- Why is inheritance better than duplicating the same code?
            // avoids code duplication and makes the code easier to maintain.


            #endregion


            #region Question 1 part 2
            //q1 
            /*
            public struct DeliveryAddress
        {
            public string city { get; set; }
            public string street { get; set; }

            public DeliveryAddress(string city, string street)
            {
                city = city;
                street = street;
            }

            public override string ToString()
            {
                return $"{street}, {city}";
            }
        }


     

public class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Destination { get; set; }

        public Shipment( string trackingCode, string description, decimal weight,  DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        
        public virtual decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee < 0)
            {
                Console.WriteLine("Deliverycannobenegative.");
                return;
            }

            DeliveryFee = newFee;
        }
        public virtual void PrintShipment()
        {
           
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Estimated Cost{EstimatedCost}");
        }
    }

            */



            #endregion
            #region Question 2 part 2
            //q2 
            /*  public class StandardShipment : Shipment
               {
                   public StandardShipment( string trackingCode, string description,
                       decimal weight, decimal deliveryFee,  DeliveryAddress destination)
                       : 

                       base( trackingCode, description,
                           weight, deliveryFee,destination)
                   {
                   }
               }

               *****************************************************************************



       public class ExpressShipment : Shipment
               {
                   private decimal extraFee;

                   public decimal ExtraFee
                   {
                       get
                       {
                           return extraFee;
                       }

                       set
                       {
                           if (value < 0)
                           {
                               throw new ArgumentException(
                                   "ExtraFee must greater than or equal to 0");
                           }

                           extraFee = value;
                       }
                   }

                   public ExpressShipment(
                       string trackingCode,
                       string description,
                       decimal weight,
                       decimal deliveryFee,
                       DeliveryAddress destination,
                       decimal extraFee)
                       : base( trackingCode,  description,  weight,   deliveryFee,  destination)
                   {
                       ExtraFee = extraFee;
                   }

                   public override decimal EstimatedCost
                   {
                       get
                       {
                           return DeliveryFee + (Weight * 5) + ExtraFee;
                       }
                   }

                   public override void PrintShipment()
                   {
                       base.PrintShipment();
                       Console.WriteLine($"Extra Fee : {ExtraFee}");
                   }
               }
               **********************************************************************************************


       public class InternationalShipment : Shipment
               {
                   private string destinationCountry;
                   private decimal customsFee;

                   public string DestinationCountry
                   {
                       get
                       {
                           return destinationCountry;
                       }

                       set
                       {
                           if (string.IsNullOrWhiteSpace(value))
                           {
                               throw new ArgumentException(
                                   "DestinationCountry cannotbeempty.");
                           }

                           destinationCountry = value;
                       }
                   }

                   public decimal CustomsFee
                   {
                       get
                       {
                           return customsFee;
                       }

                       set
                       {
                           if (value < 0)
                           {
                               throw new ArgumentException(
                                   "CustomsFee must greater than or equal to 0.");
                           }

                           customsFee = value;
                       }
                   }


                   public InternationalShipment(
                       string trackingCode,
                       string description,
                       decimal weight,
                       decimal deliveryFee,
                       DeliveryAddress destination,
                       string destinationCountry,
                       decimal customsFee)
                       : base(
                           trackingCode,
                           description,
                           weight,
                           deliveryFee,
                           destination)
                   {
                       DestinationCountry = destinationCountry;
                       CustomsFee = customsFee;
                   }

                   public override decimal EstimatedCost
                   {
                       get
                       {
                           return DeliveryFee + (Weight * 5) + CustomsFee;
                       }
                   }

                   public override void PrintShipment()
                   {
                       base.PrintShipment();
                       Console.WriteLine($"Country    : {DestinationCountry}");
                       Console.WriteLine($"Customs Fee : {CustomsFee}");
                   }
               }





                   */


            #endregion

            #region Question 3 part 2
            // q 3 

public class DeliveryCenter
        {
            public string CenterName { get; set; }

            private Shipment[] shipments;

            private int count;

            public DeliveryCenter(string centerName)
            {
                CenterName = centerName;
                shipments = new Shipment[20];
                count = 0;
            }

           
            public bool AddShipment(Shipment shipment)
            {
                if (shipment == null)
                {
                    return false;
                }

                if (count >= 20)
                {
                    return false;
                }

                shipments[count] = shipment;
                count++;

                return true;
            }

            public Shipment this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return shipments[index];
                }

                set
                {
                    if (index < 0 || index >= count)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    shipments[index] = value;
                }
            }

            
            public Shipment this[string trackingCode]
            {
                get
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (shipments[i].TrackingCode == trackingCode)
                        {
                            return shipments[i];
                        }
                    }

                    return null;
                }
            }

            public bool RemoveShipment(string trackingCode)
            {
                for (int i = 0; i < count; i++)
                {
                    if (shipments[i].TrackingCode == trackingCode)
                    {
                        
                        for (int j = i; j < count - 1; j++)
                        {
                            shipments[j] = shipments[j + 1];
                        }

                        shipments[count - 1] = null;
                        count--;

                        return true;
                    }
                }

                return false;
            }

          
            public void PrintAllShipments()
            {
                Console.WriteLine();
                Console.WriteLine($"===== {CenterName} =====");

                if (count == 0)
                {
                    Console.WriteLine("No shipments available.");
                    return;
                }

                for (int i = 0; i < count; i++)
                {
                    shipments[i].PrintShipment();
                }
            }
        }




















            #endregion




    }
    }
}
