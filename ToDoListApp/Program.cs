using ToDoListApp.Services;
using ToDoListApp.Models;

class program
{
    
    static void Main(string[] args)
    {
        
        ToDoService k = new ToDoService();
        //TodoItem    i=new TodoItem();
        while (true)
        {
        Console.WriteLine("*************Bir işlemi seçiniz**************");
        Console.WriteLine("1.görev ekle");
        Console.WriteLine("2.görev gücelleme");
        Console.WriteLine("3.görev silme");
        Console.WriteLine("4.çıkış");
        Console.WriteLine("*********************************************");
        Console.Write("SEÇİMİNİZ:");
        int islem = Convert.ToInt32(Console.ReadLine());
       


            switch (islem)
            {


                case 1:
                    Console.Write("görevinizin başlığını giriniz  :");
                    string x = Console.ReadLine();
        Console.WriteLine("***************GÖREV DETAYLARI****************");
                    k.AddTodoItem(x);
                    Console.WriteLine();
                    break;


                case 2:
                    Console.WriteLine("görevinizin güncellemelerini yapınız");

                    Console.Write("güncellenecek ID yi yazınız       :");
                    int secilenID = Convert.ToInt32(Console.ReadLine()); //şunların kısayolu varmı

                    Console.Write("yeni görev başlığını yazınız :");
                    string yeniTittle = Console.ReadLine();

                    Console.Write("yeni tamamalanma durumunu yazın :");
                    bool yeniDurum = false;
                    string t = Console.ReadLine();
                    if (t == "evet"||t=="Evet"||t=="EVET")
                        yeniDurum = true;
                    else if (t == "hayır"||t=="Hayır"||t=="HAYIR")
                        yeniDurum = false;
                    else
                        Console.WriteLine("XXXgeçerli bir durum girinizXXX");



                    DateTime yeniDate = DateTime.Now;
                    Console.WriteLine("***************GÖREV DETAYLARI****************");

                    k.UpdateTodoItem(secilenID, yeniTittle, yeniDurum, yeniDate);
         
                    break;
                case 3:
                    Console.Write("siliceğiniz listenin ID sini giriniz :");
                    int silID=Convert.ToInt32(Console.ReadLine());
                    k.DeleteToDoItem(silID);
                    break;





                case 4: return;


                default:
                    Console.WriteLine("Yanlış seçim yaptınız tekrar deneyin..");
                    break;
            }
        }
    }
}