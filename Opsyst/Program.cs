using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opsyst
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
            string choice;
            do
            {
                choice = p.menuDisplay();
                if (choice == "1")
                {
                    p.fcfs();
                }
                else if (choice == "2")
                {
                    p.sstf();
                }
                else if (choice == "3")
                {
                    p.scan();
                }
                else if (choice == "4")
                {
                    p.cscan();
                }
                else if (choice == "5")
                {
                    p.look();
                }
                else if (choice == "6")
                {
                    p.clook();
                }
                else if (choice == "7")
                {
                    Console.WriteLine("\nThank you for using the program");
                }
                else
                {
                    Console.WriteLine("\nInvalid Input");
                }
            } while (choice != "7");
            //getch();
            Console.ReadKey();
            //return 0;
        }

        public string menuDisplay()
        {

            Console.WriteLine("\nDISK SCHEDULING ALGORITHMS");
            Console.WriteLine("[1] FCFS ");
            Console.WriteLine("[2] SSTF ");
            Console.WriteLine("[3] SCAN ");
            Console.WriteLine("[4] CSCAN ");
            Console.WriteLine("[5] LOOK ");
            Console.WriteLine("[6] CLOOK ");
            Console.WriteLine("[7] Exit");
            Console.Write("Choice: ");
            string choice;
            choice = Console.ReadLine();
            return choice;
        }

        public void fcfs()
        {
            Console.WriteLine("\nSHOW FIRST COME FIRST SERVE");
            int i,j,sum=0,n;
            int[] ar = new int[20], tm = new int[20];
            int disk;

            string inp; 
            Console.Write("Enter number of location: "); 
            inp = Console.ReadLine();
            n = Convert.ToInt32(inp); 
            Console.Write("Enter position of head: "); 
            inp = Console.ReadLine();
            disk = Convert.ToInt32(inp); 
            Console.WriteLine("Enter elements of disk queue:"); 
            for (i = 0; i < n; i++)
            {
                Console.Write("Track " + (i + 1) + " : ");
                inp = Console.ReadLine();
                ar[i] = Convert.ToInt32(inp);
                tm[i]=disk-ar[i];
                if(tm[i]<0)
                {
                    tm[i]=ar[i]-disk;
                }
                disk=ar[i];
                sum=sum+tm[i];
                
            }
            for(int k = 0;k < n; k++)
                Console.Write(tm[k] + "-");

            Console.WriteLine("\nTotal Head Movements: " + sum); 
            
        }

        public void sstf()
        {
            Console.WriteLine("\nSHOW Shortest seek time first");
            int []arr = { 98, 183, 37, 122, 14, 124, 65, 67 };  
            shortestSeekTimeFirst(arr, 53); 

        }

        public void scan()
        {
            Console.WriteLine("\nSHOW SCAN");
            int i, j, sum = 0, n;
            int[] d = new int[20];
            int disk;   //loc of head
            int temp, max;
            int dloc;   //loc of disk in array
            string inp; 
            Console.Write("Enter number of location: "); 
            inp = Console.ReadLine();
            n = Convert.ToInt32(inp); 
            Console.Write("Enter position of head: "); 
            inp = Console.ReadLine();
            disk = Convert.ToInt32(inp); 
            Console.WriteLine("Enter elements of disk queue:"); 
            for (i = 0; i < n; i++)
            {
                Console.Write("Track " + (i + 1) + " : ");
                inp = Console.ReadLine();
                d[i] = Convert.ToInt32(inp); 
            }
            d[n] = disk;
            n = n + 1;
            for (i = 0; i < n; i++)    // sorting disk locations
            {
                for (j = i; j < n; j++)
                {
                    if (d[i] > d[j])
                    {
                        temp = d[i];
                        d[i] = d[j];
                        d[j] = temp;
                    }
                }
            }
            max = d[n];
            Console.WriteLine("MAX : " + max);
            dloc = 0;
            for (i = 0; i < n; i++)   // to find loc of disc in array
            {
                if (disk == d[i]) { dloc = i; break; }
            } 
            Console.WriteLine("===");
            Console.WriteLine("Movements");
            for (i = dloc; i >= 0; i--)
            {
                int hm = 0;
                if (i != 0)
                    hm = (d[i] - d[i - 1]);
                else hm = d[i];
                Console.Write(hm + "-"); 
            }
            Console.Write("0-"); 
            for (i = dloc; i < n; i++)
            {
                int hm = 0;
                if (i == dloc)
                    hm = d[i + 1] - 0;
                else hm = (d[i + 1] - d[i]);
                Console.Write(hm + "-"); 
            }
            Console.WriteLine("====");

            for (i = dloc; i >= 0; i--)
            {
                if (i != 0)
                    sum += (d[i] - d[i - 1]);
                else sum += d[i]; 
                Console.Write(d[i] + " --> "); 
            }
            Console.Write("0 -->"); 
            for (i = dloc; i < n; i++)
            {
                if (i == (n - 1)) break;
                if (i == dloc)
                    sum += (d[i + 1] - 0);
                else
                {
                    if (d[i + 1] > d[i])
                        sum += (d[i + 1] - d[i]);
                    else
                        sum += (d[i] - d[i + 1]);
                } 
                Console.Write(d[i]);
                if(i != n-2) Console.Write(" --> "); 
            } 
            Console.WriteLine("\nTotal Head Movements: " + sum); 
        }

        public void cscan()
        {
            /*
            int i = 0, curr_val = 0, sav_val = ran_array[start], difference = 0;
	        int head_movement = 0, curr_i = 0;

	        for(i = start-1; i >= 0; --i) {

		        curr_val = ran_array[i];
		        difference = abs(sav_val - curr_val);
		        head_movement += difference;
		        sav_val = curr_val;

	        }

	        /* used to subtract value from zero, or just add same value *
	        head_movement += sav_val;
	        sav_val = 0;

	        for(i = start+1; i < REQUESTS; i++) {

		        curr_val = ran_array[i];
		        difference = abs(curr_val - sav_val);
		        head_movement += difference;
		        sav_val = curr_val;

	        }*/

            Console.WriteLine("\nSHOW C-SCAN");
        }

        public void look()
        {

            Console.WriteLine("\nSHOW LOOK");
        }

        public void clook()
        {

            Console.WriteLine("\nSHOW C-LOOK");
        }

        // Calculates difference of each  
        // track number with the head position 
        public static void calculateDifference(int []queue,  
                                            int head, node []diff) 
                                          
        { 
            for (int i = 0; i < diff.Length; i++) 
                diff[i].distance = Math.Abs(queue[i] - head); 
        } 
  
        // find unaccessed track  
        // which is at minimum distance from head 
        public static int findMin(node []diff) 
        { 
            int index = -1, minimum = int.MaxValue; 
  
            for (int i = 0; i < diff.Length; i++) 
            { 
                if (!diff[i].accessed && minimum > diff[i].distance) 
                { 
                  
                    minimum = diff[i].distance; 
                    index = i; 
                } 
            } 
            return index; 
        } 
  
        public static void shortestSeekTimeFirst(int []request,  
                                                        int head) 
        { 
            if (request.Length == 0) 
                return; 
              
            // create array of objects of class node  
            node []diff = new node[request.Length];  
          
            // initialize array 
            for (int i = 0; i < diff.Length; i++)  
          
                diff[i] = new node(); 
          
            // count total number of seek operation  
            int seek_count = 0;  
          
            // stores sequence in which disk access is done 
            int[] seek_sequence = new int[request.Length + 1];  
          
            for (int i = 0; i < request.Length; i++) 
            { 
              
                seek_sequence[i] = head; 
                calculateDifference(request, head, diff); 
              
                int index = findMin(diff); 
              
                diff[index].accessed = true; 
              
                // increase the total count 
                seek_count += diff[index].distance;  
              
                // accessed track is now new head 
                head = request[index];  
            } 
          
            // for last accessed track 
            seek_sequence[seek_sequence.Length - 1] = head;  
          
            Console.WriteLine("\nTotal number of seek operations = "
                                                        + seek_count); 
                                                      
            Console.WriteLine("\nSeek Sequence is"); 
          
            // print the sequence 
            for (int i = 0; i < seek_sequence.Length; i++){
                Console.Write(seek_sequence[i]);
                if(i != seek_sequence.Length - 1) Console.Write(" -> ");
            }
        } 

    }
    public class node 
    { 
      
        // represent difference between  
        // head position and track number 
        public int distance = 0;  
      
        // true if track has been accessed 
        public Boolean accessed = false;  
    } 
}
