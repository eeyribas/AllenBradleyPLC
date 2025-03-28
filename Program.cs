using LibplctagWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AllenBradleyPLC
{
    class Program
    {
        private const int dataTimeout = 5000;

        static void Main(string[] args)
        {
            try
            {
                // Create Tags
                var tag1 = new Tag("172.24.2.131", "1, 0", CpuType.LGX, "tagValue1", DataType.DINT, 1);
                var tag2 = new Tag("172.24.2.131", "1, 0", CpuType.LGX, "tagValue2", DataType.DINT, 1);
                var tag3 = new Tag("172.24.2.131", "1, 0", CpuType.LGX, "tagValue3", DataType.INT, 1);
                var tag4 = new Tag("172.24.2.131", "1, 0", CpuType.LGX, "tagValue4", DataType.Int16, 1);

                // Read
                using (var client = new Libplctag())
                {
                    // Add Tags
                    client.AddTag(tag1);
                    client.AddTag(tag2);
                    client.AddTag(tag3);
                    client.AddTag(tag4);

                    // Tags Control
                    while (client.GetStatus(tag1) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag1) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag1))}\n");
                        return;
                    }

                    while (client.GetStatus(tag2) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag2) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag2))}\n");
                        return;
                    }

                    while (client.GetStatus(tag3) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag3) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag3))}\n");
                        return;
                    }

                    while (client.GetStatus(tag4) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag4) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag4))}\n");
                        return;
                    }

                    // Read Tags
                    var readResult1 = client.ReadTag(tag1, dataTimeout);
                    var readResult2 = client.ReadTag(tag2, dataTimeout);
                    var readResult3 = client.ReadTag(tag3, dataTimeout);
                    var readResult4 = client.ReadTag(tag4, dataTimeout);

                    // Checking the Read Tag Value
                    if (readResult1 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {readResult1}: {client.DecodeError(readResult1)}\n");
                        return;
                    } 
                    else if (readResult2 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {readResult2}: {client.DecodeError(readResult2)}\n");
                        return;
                    } 
                    else if (readResult3 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {readResult3}: {client.DecodeError(readResult3)}\n");
                        return;
                    }
                    else if (readResult4 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {readResult4}: {client.DecodeError(readResult4)}\n");
                        return;
                    }

                    var tagValue1 = client.GetInt32Value(tag1, 0 * tag1.ElementSize);
                    var tagValue2 = client.GetInt32Value(tag2, 0 * tag1.ElementSize);
                    var tagValue3 = client.GetInt16Value(tag3, 0 * tag1.ElementSize);
                    var tagValue4 = client.GetInt16Value(tag4, 0 * tag1.ElementSize);
                    Console.WriteLine("Tag Value - 1 : " + tagValue1);
                    Console.WriteLine("Tag Value - 2 : " + tagValue2);
                    Console.WriteLine("Tag Value - 3 : " + tagValue3);
                    Console.WriteLine("Tag Value - 4 : " + tagValue4);
                }

                // Write
                using (var client = new Libplctag())
                {
                    // Add Tags
                    client.AddTag(tag1);
                    client.AddTag(tag2);
                    client.AddTag(tag3);
                    client.AddTag(tag4);

                    // Tags Control
                    while (client.GetStatus(tag1) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag1) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag1))}\n");
                        return;
                    }

                    while (client.GetStatus(tag2) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag2) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag2))}\n");
                        return;
                    }

                    while (client.GetStatus(tag3) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag3) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag3))}\n");
                        return;
                    }

                    while (client.GetStatus(tag4) == Libplctag.PLCTAG_STATUS_PENDING)
                        Thread.Sleep(100);
                    if (client.GetStatus(tag4) != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"Error setting up tag internal state. Error { client.DecodeError(client.GetStatus(tag4))}\n");
                        return;
                    }
     
                    // Write Values
                    client.SetInt32Value(tag1, 0 * tag1.ElementSize, 500);
                    client.SetInt32Value(tag2, 0 * tag2.ElementSize, 200);
                    client.SetInt16Value(tag3, 0 * tag3.ElementSize, 150);
                    client.SetInt16Value(tag4, 0 * tag4.ElementSize, 1);
                    var writeResult1 = client.WriteTag(tag1, dataTimeout);
                    var writeResult2 = client.WriteTag(tag2, dataTimeout);
                    var writeResult3 = client.WriteTag(tag3, dataTimeout);
                    var writeResult4 = client.WriteTag(tag4, dataTimeout);

                    // Checking the Write Tag Value
                    if (writeResult1 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {writeResult1}: {client.DecodeError(writeResult1)}\n");
                        return;
                    }
                    else if (writeResult2 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {writeResult2}: {client.DecodeError(writeResult2)}\n");
                        return;
                    }
                    else if (writeResult3 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {writeResult3}: {client.DecodeError(writeResult3)}\n");
                        return;
                    }
                    else if (writeResult4 != Libplctag.PLCTAG_STATUS_OK)
                    {
                        Console.WriteLine($"ERROR: Unable to read the data! Got error code {writeResult4}: {client.DecodeError(writeResult4)}\n");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
