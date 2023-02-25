using System;
using System.IO;


namespace Lab_15_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write \"help\" for more information");
            bool loop_continue = true;
            string command;
            string command_line;
            list_one list = null;
            while (loop_continue)
            {
                Console.Write("<Teacher list program>");
                command_line = Console.ReadLine();
                command = command_line.Split(' ')[0];
                switch (command)
                {
                    case "help":
                        {
                            Console.WriteLine("create1 - create new one directed list");
                            Console.WriteLine("create1 - create new two directed list");
                            Console.WriteLine("show - show list");
                            Console.WriteLine("count - count elements of list");
                            Console.WriteLine("check - true if list not null");
                            Console.WriteLine("insert 'value' - insert new element (value) in start of list");
                            Console.WriteLine("\t-end 'value' - insert new element (value) in the end of list");
                            Console.WriteLine("\t-pos 'position' 'value' - insert new element (value) on the posotion (position) in list");
                            Console.WriteLine("del - deleting list");
                            Console.WriteLine("\t-a - delete all elements in list");
                            Console.WriteLine("\t-id 'index' - delete elemend on position index");
                            Console.WriteLine("\t-el 'value' - delete first element contain value");
                            Console.WriteLine("\t-els 'value' - delete all elements contain value");
                            Console.WriteLine("edit 'index' 'value' - edit element of list in position (index)");
                            Console.WriteLine("reaplace 'value' 'new_value' - replace all elements contain value to new_value");
                            Console.WriteLine("find 'value' - search all elements contain value and show it");
                            Console.WriteLine("sort - sortind elements in list");
                            Console.WriteLine("save 'path' - save list in text file by path");
                            Console.WriteLine("read 'path' - read list and set for work from path");
                            Console.WriteLine("exit - close program");
                        }
                        break;
                    case "create1":
                        list = new list_one();
                        break;
                    case "create2":
                        list = new list_two();
                        break;
                    case "show":
                        list.Show();
                        break;
                    case "count":
                        Console.WriteLine(list.Count());
                        break;
                    case "check":
                        if (list == null)
                        {
                            Console.WriteLine("You didn`t create list yet");
                        }
                        else
                        {
                            Console.WriteLine(list.Check());
                        }
                        break;
                    case "insert":
                        string insert_key = command_line.Split(' ')[1];
                        switch (insert_key)
                        {
                            case "-end":
                                list.InsertEnd(command_line.Split(' ')[2]);
                                break;
                            case "-pos":
                                if (!list.InsertPos(command_line.Split(' ')[3], int.Parse(command_line.Split(' ')[2])))
                                {
                                    Console.WriteLine("Not enough elements");
                                }
                                break;
                            default:
                                list.Insert(command_line.Split(' ')[1]);
                                break;
                        }
                        break;
                    case "del":
                        string del_key = null;
                        if (command_line.Split(' ').Length >= 1)
                        {
                            del_key = command_line.Split(' ')[1];
                        }
                        else
                        {
                            del_key = "";
                        }
                        switch (del_key)
                        {
                            case "-a":
                                list.ClearAll();
                                break;
                            case "-id":
                                list.DelPos(int.Parse(command_line.Split(' ')[2]));
                                break;
                            case "-el":
                                list.DelValue(command_line.Split(' ')[2]);
                                break;
                            case "-els":
                                list.DelValueAll(command_line.Split(' ')[2]);
                                break;
                            default:
                                list.Clear();
                                break;
                        }
                        break;
                    case "edit":
                        if(!list.Edit(int.Parse(command_line.Split(' ')[1]), command_line.Split(' ')[2]))
                        {
                            Console.WriteLine("Not enough elements");
                        }
                        break;
                    case "replace":
                        list.Replace(command_line.Split(' ')[1], command_line.Split(' ')[2]);
                        break;
                    case "find":
                        list.Find(command_line.Split(' ')[1]);
                        break;
                    case "sort":
                        list.Sort();
                        break;
                    case "save":
                        list.Save(command_line.Split(' ')[1]);
                        break;
                    case "read":
                        list.Read(command_line.Split(' ')[1]);
                        break;
                    case "exit":
                        loop_continue = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }

            }
        }
    }
}
