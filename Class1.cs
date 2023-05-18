namespace file_c_
{


    internal class Class1
    {
        public static void task1()
        {
            string path = "C:\\Users\\Asus\\source\\repos\\file_c#\\text.txt";

            Console.WriteLine("Меню:");
            Console.WriteLine("1. Переглянути вміст файлу");
            Console.WriteLine("2. Зберегти масив у файл");
            Console.WriteLine("3. Завантажити масив з файлу");
            Console.WriteLine("4. Вийти");

            while (true)
            {
                Console.Write("Виберіть опцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewFileContent(path);
                        break;
                    case "2":
                        SaveArrayToFile(path);
                        break;
                    case "3":
                        LoadArrayFromFile(path);
                        break;
                    case "4":
                        Console.WriteLine("До побачення!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ViewFileContent(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при прочитанні: " + ex.Message);
            }
        }

        static void SaveArrayToFile(string path)
        {


            Console.Write("Введіть елементи масиву (розділені пробілами): ");
            string input = Console.ReadLine();
            string[] array = input.Split(' ');

            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                       
                       foreach (var item in array)
                       {
                           sw.Write(item + " ");
                       }
                    }
                }

                Console.WriteLine("Масив успішно збережено у файлі.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при збереженні масиву у файл: " + ex.Message);
            }
        }

        static void LoadArrayFromFile(string path)
        {


            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        string fileContent = sr.ReadLine();
                        string[] array = fileContent.Split(' ');

                        Console.WriteLine("Масив, завантажений з файлу:");
                        foreach (var item in array)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка при завантаженні масиву з файлу: " + ex.Message);
            }
        }

    }
}



