using System;
using System.Linq;
using HomeWork.Abstract;
using HomeWork.Entity;

namespace HomeWork
{
    class Program
    {
        //static IDivisionRepository divisionRepository;
        static void helpText() {
            Console.WriteLine("For use:");
            Console.WriteLine("\thomework [command] [parameters]\n");
            Console.WriteLine("Commands:");
            Console.WriteLine("\tshow realtors\t\tshow all Realtors in base");
            Console.WriteLine("\tshow divisions\t\tshow all Divisions in base");
            Console.WriteLine("\tadd division [Name]\t\tAdd Division to base");
            Console.WriteLine("\tdel division [Name]\t\tDelete Division from base");
        }
        static void Main(string[] args)
        {
            if (args.Length > 0) {
                if (args[0].ToLower() == "show" && args[1].ToLower() == "realtors") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        // получаем объекты из бд и выводим на консоль
                        var realtors = db.Realtor.Join(db.Division, p => p.Division, c => c.Id, (p, c) => new {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Name = c.Name,
                            CreatedDateTime = p.CreatedDateTime
                        }).ToList();
                        Console.WriteLine("Список риелторов:");
                        foreach (var r in realtors) {
                            Console.WriteLine($"{r.Id}\t{r.FirstName} {r.LastName}\t{r.Name}\t{r.CreatedDateTime}");
                        }
                    }
                } else if (args[0].ToLower() == "show" && args[1].ToLower() == "divisions") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        var divisions = db.Division.ToList();
                        Console.WriteLine("Список подразделений:");
                        foreach (Division d in divisions) {
                            Console.WriteLine($"{d.Id}\t{d.Name}\t{d.CreatedDateTime}");
                        }
                    }
                } else if (args[0].ToLower() == "add"
                   && args[1].ToLower() == "realtor"
                   && args[2].ToLower() != ""
                   && args[3].ToLower() != ""
                   && args[4].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        Realtor rlt = new Realtor() {
                            FirstName = args[2],
                            LastName = args[3],
                            Division = Convert.ToInt32(args[4]),
                            CreatedDateTime = DateTime.Now
                        };
                        db.Realtor.Add(rlt);
                        db.SaveChanges();
                        Console.WriteLine($"Realtor {args[2]} {args[3]} was added to base.");
                    }
                } else if (args[0].ToLower() == "add"
                        && args[1].ToLower() == "division"
                        && args[2].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        Division dev = new Division() {
                            Name = args[2],
                            CreatedDateTime = DateTime.Now
                        };
                        db.Division.Add(dev);
                        db.SaveChanges();
                        Console.WriteLine($"Division {args[2]} was added to base.");
                    }
                } else if (args[0].ToLower() == "del"
                    && args[1].ToLower() == "realtor"
                    && args[2].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        if (db.Realtor.Where(d => d.Id == Convert.ToInt32(args[2])).Count() > 0) {
                            Realtor rlt = new Realtor() {
                                Id = Convert.ToInt32(args[2])
                            };
                            db.Realtor.Remove(rlt);
                            db.SaveChanges();
                            Console.WriteLine($"Realtor with ID:{args[2]} was deleted from base.");
                        } else {
                            Console.WriteLine("Error: ID Realtor not found in base!");
                        };
                    }
                } else if (args[0].ToLower() == "del"
                        && args[1].ToLower() == "division"
                        && args[2].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        if (db.Division.Where(d => d.Id == Convert.ToInt32(args[2])).Count() > 0) {
                            Division dev = new Division() {
                                Id = Convert.ToInt32(args[2])
                            };
                            db.Division.Remove(dev);
                            db.SaveChanges();
                            Console.WriteLine($"Division {args[2]} was deleted from base.");
                        } else {
                            Console.WriteLine("Error: ID Division not found in base!");
                        };
                    }
                } else if (args[0].ToLower() == "update"
                   && args[1].ToLower() == "realtor"
                   && args[2].ToLower() != ""
                   && args[3].ToLower() != ""
                   && args[4].ToLower() != ""
                   && args[5].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        if (db.Realtor.Where(d => d.Id == Convert.ToInt32(args[2])).Count() > 0) {
                            Realtor rlt = new Realtor() {
                                Id = Convert.ToInt32(args[2]),
                                FirstName = args[3],
                                LastName = args[4],
                                Division = Convert.ToInt32(args[5]),
                                CreatedDateTime = DateTime.Now
                            };
                            db.Realtor.Update(rlt);
                            db.SaveChanges();
                            Console.WriteLine($"Realtor with ID:{args[2]} {args[3]} {args[4]} in {args[5]} was updated in base.");
                        } else {
                            Console.WriteLine("Error: ID Realtor not found in base!");
                        };
                    }
                } else if (args[0].ToLower() == "update"
                   && args[1].ToLower() == "division"
                   && args[2].ToLower() != ""
                   && args[3].ToLower() != "") {
                    using (HomeWorkContext db = new HomeWorkContext()) {
                        if (db.Division.Where(d => d.Id == Convert.ToInt32(args[2])).Count() > 0) {
                            Division dev = new Division() {
                                Id = Convert.ToInt32(args[2]),
                                Name = args[3],
                                CreatedDateTime = DateTime.Now
                            };
                            db.Division.Update(dev);
                            db.SaveChanges();
                            Console.WriteLine($"Division {args[2]} was updated in base.");
                        } else {
                            Console.WriteLine("Error: ID Division not found in base!");
                        };
                    }
                } else {
                    helpText();
                }
            } else {
                helpText();
            }

            Console.Write("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
