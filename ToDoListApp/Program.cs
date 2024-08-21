using ToDoListApp.Services;
using ToDoListApp.Models;

class program
{
    private static string listName;

    static void Main(string[] args)
    {
        Console.WriteLine("Merhaba! Görev Listesi Uygulamasına Hoş Geldiniz...");
        Console.WriteLine("Lütfen görev listesine bakacağınız günü veya iş tanımını yapınız... ");
        Console.WriteLine("(örnek: 'pazartesi','cumartesi','işyeri','evişleri')");
        
        
        //TodoItem    i=new TodoItem();
        while (true)
        {
            Console.Write("Görev Listesi Adı  :");

            var listname = Console.ReadLine(); //Kullanıcıdan bir görev listesi adı istenir. Bu ad, uygulamanın yönetmek istediği görev listesinin belirleyicisidir.
            ToDoService k = new ToDoService(listName: listname);
            Console.WriteLine($"Şu an '{listName}' adlı listeyi yönetiyorsunuz.");
        Console.WriteLine("*************Bir işlemi seçiniz**************");
        Console.WriteLine("1.görev ekle");
        Console.WriteLine("2.görev gücelleme");
        Console.WriteLine("3.görev silme");
        Console.WriteLine("4.Tamamlanma Durumu Güncelleme");
        Console.WriteLine("5.yazdır");
        Console.WriteLine("6.çıkış");
        Console.WriteLine("*********************************************");
        Console.Write("SEÇİMİNİZ:");
        int islem = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
       


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
                    int secilenID = Convert.ToInt32(Console.ReadLine()); // daha tasarruflu yolu var mı?

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


                case 4:
                    Console.Write("Tamamlanma durumunu değiştirmek istediğiniz ID değerini giriniz :");
                    int Durum_ID=Convert.ToInt32(Console.ReadLine());
                    Console.Write("Tamamlandı mı? (Evet/Hayır)");
                    bool Tamamlandi_mi=false;
                    string yes_or_no = Console.ReadLine();
                    if (yes_or_no == "evet" || yes_or_no == "Evet" || yes_or_no == "EVET")
                        Tamamlandi_mi = true;
                    else if (yes_or_no == "hayır" || yes_or_no == "Hayır" || yes_or_no == "HAYIR")
                        Tamamlandi_mi = false;
                    else
                        Console.WriteLine("XXXgeçerli bir durum girinizXXX");


                    k.IsCompleced(Durum_ID, Tamamlandi_mi);


                    break;

                case 5:
                    k.YAZ();
                    break;





                case 6: return;


                default:
                    Console.WriteLine("Yanlış seçim yaptınız tekrar deneyin..");
                    break;
            }
        }
    }
}