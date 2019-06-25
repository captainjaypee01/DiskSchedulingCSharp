using System;

public class SstfSchedule
{
    // Calculates difference of each  
    // track number with the head position 
    public static void calculateDifference(int[] queue,
                                        int head, node[] diff)

    {
        for (int i = 0; i < diff.Length; i++)
            diff[i].distance = Math.Abs(queue[i] - head);
    }

    // find unaccessed track  
    // which is at minimum distance from head 
    public static int findMin(node[] diff)
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

    public static void shortestSeekTimeFirst(int[] request,
                                                    int head)
    {
        if (request.Length == 0)
            return;

        // create array of objects of class node  
        node[] diff = new node[request.Length];

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

        Console.WriteLine("Total number of seek operations = "
                                                    + seek_count);

        Console.WriteLine("Seek Sequence is");

        // print the sequence 
        for (int i = 0; i < seek_sequence.Length; i++)
            Console.WriteLine(seek_sequence[i]);
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
