using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models; //models dosyasını kullacağımız için kütüphanemize ekledik
using System.Text.Json; //D
using System.IO;       //D


namespace ToDoListApp.Services
{
    public class ToDoService 
    {
       
       // List<TodoItem> _todoItems = new (); //veri tipine sınıf koydum, değişkeni sınıf nesnesi olan bir liste oluşturdum
        private List<TodoItem> _todoItems; //D
        
        private int nextID = 1;
        private readonly string _filePath = "todo h5items.json"; //D

        public ToDoService(string listName)
        {
            // Program başlarken dosyadan mevcut görevleri yükler.
             _filePath = $"{listName}.json";
            _todoItems = LoadTodoItemsFromFile();
             nextID = _todoItems.Count > 0 ? _todoItems[^1].Id + 1 : 1;
        }


        TodoItem item = new TodoItem();                                    
        public void AddTodoItem(string title)  //ekle metodu
        {
            TodoItem item = new TodoItem();
            Console.WriteLine();
            item.Id = nextID++;                                              //yukarda oluşturduğum item nesnesinden değişkenlerimi alıp girilen girdilere göre değiştiriyorum
            item.Title = title;                           
            item.CreatedDate = DateTime.Now;
            item.IsCompleted = false;

            
            _todoItems.Add(item);             //direkt nesne tipinden listeye ekleme gerçekleştiriyorum
           
            SaveTodoItemsToFile();//D

            Console.WriteLine("----------------------------------------");
            Console.WriteLine();


            
            foreach (TodoItem i in _todoItems) 
            {
                Console.WriteLine("            "   +     i.Id+" NUMARALI GÖREV               "                    );
                Console.WriteLine("ID------------------>"+i.Id);
                Console.WriteLine("Başlık-------------->" + i.Title);
                Console.WriteLine("Tarih--------------->" + i.CreatedDate);
                Console.WriteLine("Tamamlanma Durumu--->"+i.IsCompleted);
                Console.WriteLine();

            }
            Console.WriteLine("--------------------------------------");

           

        }

        public void UpdateTodoItem(int id,string title,bool isCompleted,DateTime newDate) //güncelleme metodu
        {
            TodoItem item = new TodoItem();

           TodoItem? foundItem = _todoItems.Find(item => item.Id == id);   //verdiğin ID deki listeyi bulup foundItem e atar *************


            if (foundItem != null)
            {
                foundItem.Title = title;
                foundItem.IsCompleted=isCompleted;
                
            }
            else
            {
                Console.WriteLine("liste boş..");
            }

            foreach (TodoItem i in _todoItems)
            {
                Console.WriteLine();
                Console.WriteLine("            " + i.Id + " NUMARALI GÖREV               ");
                Console.WriteLine("ID------------------>" + i.Id);
                Console.WriteLine("Başlık-------------->" + i.Title);
                Console.WriteLine("Tarih--------------->" + i.CreatedDate);
                Console.WriteLine("Tamamlanma Durumu--->" + i.IsCompleted);
                Console.WriteLine();

            }
    
           

        }

        public void DeleteToDoItem(int id)       //silme metodu

        {
            
            int index=_todoItems.FindIndex(item=>item.Id==id);
            if (index > -1) {
                _todoItems.RemoveAt(index);
            }
            
            Console.WriteLine("------------------------");
            foreach (TodoItem i in _todoItems)
            {
                Console.WriteLine("            " + i.Id + " NUMARALI GÖREV               ");
                Console.WriteLine("ID------------------>" + i.Id);
                Console.WriteLine("Başlık-------------->" + i.Title);
                Console.WriteLine("Tarih--------------->" + i.CreatedDate);
                Console.WriteLine("Tamamlanma Durumu--->" + i.IsCompleted);
                Console.WriteLine();

            }
            Console.WriteLine("------------------------");


        }

        public void IsCompleced(int id,bool x)
        {
            TodoItem item=new TodoItem();
            var found = _todoItems.Find(i => i.Id == id);
            if (found != null) 
            {
                found.IsCompleted = x;
            }
            else
                Console.WriteLine("geçerli ID no giriniz");


            foreach (TodoItem i in _todoItems)
            {
                Console.WriteLine();
                Console.WriteLine("            " + i.Id + " NUMARALI GÖREV               ");
                Console.WriteLine("ID------------------>" + i.Id);
                Console.WriteLine("Başlık-------------->" + i.Title);
                Console.WriteLine("Tarih--------------->" + i.CreatedDate);
                Console.WriteLine("Tamamlanma Durumu--->" + i.IsCompleted);
                Console.WriteLine();

            }

        } //tamamlanma durumu güncelleme
        
        public void YAZ() //yazdırma metodu
        {
            foreach (TodoItem item in _todoItems)
            {
                Console.WriteLine("ID------------------>" + item.Id);
                Console.WriteLine("Başlık-------------->" + item.Title);
                Console.WriteLine("Tarih--------------->" + item.CreatedDate);
                Console.WriteLine("Tamamlanma Durumu--->" + item.IsCompleted);

            }
        }

        public List<TodoItem> GetAllTodoItems()
        {
            return new List<TodoItem>(_todoItems);
        }

        private void SaveTodoItemsToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_todoItems, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        private List<TodoItem> LoadTodoItemsFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    var json = File.ReadAllText(_filePath);
                    return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }

            return new List<TodoItem>();
        }
    }
}
