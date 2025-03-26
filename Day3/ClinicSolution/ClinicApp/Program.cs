using ClinicApp.Exceptions;
using ClinicApp.Interfaces;
using ClinicApp.Models;
using ClinicApp.Services;
using System;

namespace ClinicApp
{
    internal class Program
    {
        IDoctorAuthenticate doctorAuthenticate;
        DoctorService doctorService;
        IAdminWork adminWork;
        public Program(DoctorService service)
        {
            //doctorService = new DoctorServiceV1();//Tight Coupling
            doctorService = service;//loose coupling
        }
        void PrintAdminMenu()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. View Doctor Listing");
            Console.WriteLine("3. Activate/De-Activate Doctor");
            Console.WriteLine("4. Exit");

        }
        void PrintDoctorMenu()
        {
            Console.WriteLine("1. Register Doctor");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
        }
        void AdminInteraction()
        {
            adminWork = doctorService;
            int choice = 0;
            bool isLoggedIn = false;
            do
            {
                PrintAdminMenu();
                Console.WriteLine("Enter your choice");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (choice)
                {
                    case 1:
                        isLoggedIn = AdminLogin(adminWork);
                        break;
                    case 2:
                        if (isLoggedIn)
                        {
                            PrintDoctors(adminWork);
                        }
                        else
                        {   
                            Console.WriteLine("Please login to view the doctor listing");
                        }
                        break;
                    case 3:
                        if (isLoggedIn)
                        {
                            ChangeStatus(adminWork);
                        }
                        else
                        {
                            Console.WriteLine("Please login to change the doctor status");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while(choice != 4);

        }

        private void ChangeStatus(IAdminWork adminWork)
        {
            Console.WriteLine("Enter Doctor Id");
            int doctorId;
            while (!int.TryParse(Console.ReadLine(), out doctorId))
            {
                Console.WriteLine("Please enter a valid doctor Id");
            }
            Console.WriteLine("Enter Status (Available/NotAvailable)");
            DoctorStatus status;
            while (!Enum.TryParse(Console.ReadLine(), out status))
            {
                Console.WriteLine("Please enter a valid status");
            }
            try
            {
                if (adminWork.ChangeDoctorStatus(doctorId, status))
                {
                    Console.WriteLine("Doctor status changed successfully");
                }
            }
            catch(CollectionEmptyException cee)
            {
                Console.WriteLine(cee.Message);
            }
            catch (NoSuchEntityException nsee)
            {
                Console.WriteLine(nsee.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }

        private void PrintDoctors(IAdminWork adminWork)
        {
            try
            {
                var doctors = adminWork.GetDoctors();
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                    Console.WriteLine("---------------------");
                }
            }
            catch (CollectionEmptyException cee)
            {
                Console.WriteLine(cee.Message);
            }
        }

        private  bool AdminLogin(IAdminWork adminWork)
        {
            Console.WriteLine("Enter Username");
            string username = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine() ?? "";
            if (adminWork.AdminLogin(username, password))
            {
                Console.WriteLine("Login Successful");
                return true;
            }
            Console.WriteLine("Invalid username or password");
            return false;
        }

        void DoctorInteraction()
        {
            //((DoctorServiceV1)doctorService).NewFunctionalities(); - it violates Liskov's Substitution

            doctorAuthenticate = doctorService;
            int choice = 0;
            do
            {
                PrintDoctorMenu();
                Console.WriteLine("Enter your choice");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (choice)
                {
                    case 1:
                        Doctor doctor = new Doctor();
                        doctor.TakeDoctorDetailsFromConsole();
                        doctorAuthenticate.RegisterDoctor(doctor);
                        break;
                    case 2:
                        Login(doctorAuthenticate);
                        break;
                    case 3:
                        Console.WriteLine("Exiting from Doctor Interaction");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 3);
        }

        private void Login(IDoctorAuthenticate doctorAuthenticate)
        {
            Console.WriteLine("Enter Doctor Id");
            int doctorId;
            while (!int.TryParse(Console.ReadLine(), out doctorId))
            {
                Console.WriteLine("Please enter a valid doctor Id");
            }
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine()??"";
            Doctor result = doctorAuthenticate.Login(doctorId, password);
            if (result != null)
            {
                Console.WriteLine("Login Successful");
                Console.WriteLine("Welcome Doctor. Here are your details");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }

        static void Main(string[] args)
        {
            DoctorService obj = new DoctorServiceV1();
            Program program = new Program(obj);
            program.UserInteraction();

        }

        private void UserInteraction()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Doctor");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a valid choice");
                }
                switch (choice)
                {
                    case 1:
                        AdminInteraction();
                        break;
                    case 2:
                        DoctorInteraction();
                        break;
                    case 3:
                        Console.WriteLine("Exiting from the application");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 3);
        }
    }
}

