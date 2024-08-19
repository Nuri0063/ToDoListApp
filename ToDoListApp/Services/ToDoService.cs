using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models; //models dosyasını kullacağımız için kütüphanemize ekledik

namespace ToDoListApp.Services
{
    public class ToDoService //işevleri koyacağım class yapısı
    {
       
        List<(int Id, string Title, DateTime CreatedDate, bool IsCompleted)> _todoItems = new List<(int, string, DateTime, bool)>(); //yeni öğrendiğin liste tanımlama yöntemi

        private int _nextID = 1;

        TodoItem item = new TodoItem();                                         //TodoItem classından nesne oluşturdum ki içindeki değişkenleri kullanabileyim
        public void AddTodoItem(string title)                                  //ekle metodum
        {
            Console.WriteLine();
            item.Id = _nextID++;                                              //yukarda oluşturduğum item nesnesinden değişkenlerimi alıp girilen girdilere göre değiştiriyorum
            item.Title = title;                            
            item.CreatedDate = DateTime.Now;
            item.IsCompleted = false;


            _todoItems.Add((item.Id,title,item.CreatedDate,item.IsCompleted));

            Console.WriteLine("------------------------");
            foreach (object i in _todoItems)                             
            {
                Console.WriteLine(i);
                
            }
            Console.WriteLine("------------------------");

            /* 
            var todoItem = new TodoItem
            {
                ID = _nextID++,
                Title = title,
                CreatedDate = DateTime.Now,
                IsCompleted = false


            };
            _todoItems.Add(todoItem);
            */

        }

        public void UpdateTodoItem(int id,string title,bool isCompleted,DateTime newDate) //güncelleme metodu
        {

            
            var index = _todoItems.FindIndex(item => item.Id == id);

            if(index!= -1)
            {
                var tempIndex = _todoItems[index];
                _todoItems[index] = ( tempIndex.Id,title,tempIndex.CreatedDate,isCompleted);

                
            }
            else
               Console.WriteLine();
 
           
                //item.Title = title; //niye burdalar
                //item.IsCompleted = isCompleted;
            foreach (var item in _todoItems)
            {
                Console.WriteLine(item);

            }

        }

        public void DeleteToDoItem(int id)  //foreach ile liste üzerinde gezerken id yi bulup o idle eşleşen liste yapısını silmeyi hedefledin..

        {
            var index=_todoItems.FindIndex(item=>item.Id == id);
            
            //foreach (object i in _todoItems)
            //{
               
                
            //        _todoItems.RemoveAt(id);
                

            //}

        }

    }
}
