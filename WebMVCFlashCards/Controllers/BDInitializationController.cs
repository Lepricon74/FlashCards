using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMVCFlashCards.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVCFlashCards.Controllers
{
    [Route("[controller]")]
    public class BDInitializationController : Controller
    {
        FlashCardsContext db;
        public BDInitializationController(FlashCardsContext context)
        {
            db = context;
            if (!db.UsersDecks.Any())
            {
                //db.Users.Add(new User { Login = "vadim", Password = "12345", LanguageId = 1 });
                //db.Users.Add(new User { Login = "sasha", Password = "12345", LanguageId = 2 });
                ////db.Users.Add(new User { Login = "maxim", Password = "12345" });
                //db.SaveChanges();

                //db.LanguageTypes.Add(new LanguageType { LanguageId=1, LanguageName="English" });
                //db.LanguageTypes.Add(new LanguageType { LanguageId = 2, LanguageName = "French" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "Animals", Size = 13, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 1, Translation = "Chicken", Rus = "Курица" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 2, Translation = "Girraffe", Rus = "Жираф" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 3, Translation = "Elephant", Rus = "Слон" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 4, Translation = "Cat", Rus = "Кошка" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 5, Translation = "Cow", Rus = "Корова" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 6, Translation = "Dog", Rus = "Собака" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 7, Translation = "Duck", Rus = "Утка" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 8, Translation = "Donkey", Rus = "Осел" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 9, Translation = "Goat", Rus = "Коза" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 10, Translation = "Goose", Rus = "Гусь" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 11, Translation = "Hamster", Rus = "Хомяк" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 12, Translation = "Mouse", Rus = "Мышь" });
                //db.BasicCards.Add(new BasicCard { DeckId = 1, CardId = 0, Translation = "Pig", Rus = "Свинья" });

                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "Professions", Size = 10, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 1, Translation = "Teacher", Rus = "Учитель" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 2, Translation = "Interpreter", Rus = "Переводчик" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 3, Translation = "Waiter", Rus = "Официант" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 4, Translation = "Translationineer", Rus = "Инженер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 5, Translation = "Lawyer", Rus = "Юрист" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 6, Translation = "Accountant", Rus = "Бухгалтер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 7, Translation = "Manager", Rus = "Управляющий" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 8, Translation = "Nurse", Rus = "Медсестра" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 9, Translation = "Scientist", Rus = "Ученый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 2, CardId = 0, Translation = "Programmer", Rus = "Программист" });

                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck { Title = "Sport", Size = 12, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 1, Translation = "Football", Rus = "Футбол" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 2, Translation = "Basketball", Rus = "Баскетбол" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 3, Translation = "Swimming", Rus = "Плавание" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 4, Translation = "Baseball", Rus = "Бейсбол" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 5, Translation = "Biathlon", Rus = "Биатлон" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 6, Translation = "Aerobics", Rus = "Аэробика" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 7, Translation = "Boxing", Rus = "Бокс" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 8, Translation = "Badminton", Rus = "Бадминтон" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 9, Translation = "Fencing", Rus = "Фехтование" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 10, Translation = "Golf", Rus = "Гольф" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 11, Translation = "Judo", Rus = "Дзюдо" });
                //db.BasicCards.Add(new BasicCard { DeckId = 3, CardId = 0, Translation = "Triathlon", Rus = "Триатлон" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "IT", Size = 14, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 1, Translation = "Computer", Rus = "Компьютер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 2, Translation = "Screen", Rus = "Экран" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 3, Translation = "Keyboard", Rus = "Клавиатура" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 4, Translation = "Laptop", Rus = "Ноутбук" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 5, Translation = "Printer", Rus = "Принтер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 6, Translation = "Mouse", Rus = "Мышь" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 7, Translation = "Monitor", Rus = "Монитор" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 8, Translation = "Disk", Rus = "Диск" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 9, Translation = "Projector", Rus = "Проектор" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 10, Translation = "Internet", Rus = "Интернет" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 11, Translation = "Link", Rus = "Ссылка" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 12, Translation = "Server", Rus = "Сервер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 13, Translation = "Browser", Rus = "Браузер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 4, CardId = 0, Translation = "Program", Rus = "Программа" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "Colors", Size = 10, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 1, Translation = "Red", Rus = "Красный" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 2, Translation = "Green", Rus = "Зелёный" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 3, Translation = "Blue", Rus = "Синий" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 4, Translation = "Yellow", Rus = "Жёлтый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 5, Translation = "Black", Rus = "Чёрный" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 6, Translation = "White", Rus = "Белый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 7, Translation = "Pink", Rus = "Розовый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 8, Translation = "Orange", Rus = "Оранжевый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 9, Translation = "Brown", Rus = "Коричневый" });
                //db.BasicCards.Add(new BasicCard { DeckId = 5, CardId = 0, Translation = "Gray", Rus = "Серый" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "Transport", Size = 12, LanguageId = 1 });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 1, Translation = "Car", Rus = "Автомобиль" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 2, Translation = "Bus", Rus = "Автобус" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 3, Translation = "Airplane", Rus = "Самолёт" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 4, Translation = "Truck", Rus = "Грузовик" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 5, Translation = "Helicopter", Rus = "Вертолёт" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 6, Translation = "Motorcycle", Rus = "Мотоцикл" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 7, Translation = "Boat", Rus = "Лодка" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 8, Translation = "Ship", Rus = "Корабль" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 9, Translation = "Train", Rus = "Поезд" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 10, Translation = "Scooter", Rus = "Скутер" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 11, Translation = "Bicycle", Rus = "Велосипед" });
                //db.BasicCards.Add(new BasicCard { DeckId = 6, CardId = 0, Translation = "Van", Rus = "Фургон" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck {  Title = "La nourriture", Size = 12, LanguageId = 2 });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 1, Translation = "Le pain", Rus = "Хлеб" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 2, Translation = "Le lait", Rus = "Молоко" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 3, Translation = "La tartine", Rus = "Бутерброд" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 4, Translation = "Les oeufs", Rus = "Яйца" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 5, Translation = "Le fromage", Rus = "Сыр" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 6, Translation = "Le miel", Rus = "Мёд" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 7, Translation = "Le bacon", Rus = "Бекон" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 8, Translation = "La soupe", Rus = "Суп" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 9, Translation = "La pomme de terre", Rus = "Картошка" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 10, Translation = "Les fruits", Rus = "Фрукты" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 11, Translation = "Les légumes", Rus = "Овощи" });
                //db.BasicCards.Add(new BasicCard { DeckId = 7, CardId = 0, Translation = "Le poisson", Rus = "Рыба" });
                //db.SaveChanges();

                //db.BasicDecks.Add(new BasicDeck { Title = "L' apparence", Size = 7, LanguageId = 2 });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 1, Translation = "La barbe", Rus = "Борода" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 2, Translation = "La face", Rus = "Лицо" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 3, Translation = "L' oreille", Rus = "Ухо" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 4, Translation = "La figure", Rus = "Фигура" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 5, Translation = "Le ventre", Rus = "Живот" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 6, Translation = "Las dos", Rus = "Спина" });
                //db.BasicCards.Add(new BasicCard { DeckId = 8, CardId = 7, Translation = "La bouche", Rus = "Рот" });



                //db.UsersDecks.Add(new UserDeck { DeckId = 1, UserId = 1, Title = "Colors", Progress = 0, Size = 10 });
                //db.UsersCards.Add(new UserCard { CardId = 1, DeckId = 1, UserId = 1, Translation = "Red", Rus = "Красный" });
                //db.UsersCards.Add(new UserCard { CardId = 2, DeckId = 1, UserId = 1, Translation = "Green", Rus = "Зелёный" });
                //db.UsersCards.Add(new UserCard { CardId = 3, DeckId = 1, UserId = 1, Translation = "Blue", Rus = "Синий" });
                //db.UsersCards.Add(new UserCard { CardId = 4, DeckId = 1, UserId = 1, Translation = "Yellow", Rus = "Жёлтый" });
                //db.UsersCards.Add(new UserCard { CardId = 5, DeckId = 1, UserId = 1, Translation = "Black", Rus = "Чёрный" });
                //db.UsersCards.Add(new UserCard { CardId = 6, DeckId = 1, UserId = 1, Translation = "White", Rus = "Белый" });
                //db.UsersCards.Add(new UserCard { CardId = 7, DeckId = 1, UserId = 1, Translation = "Pink", Rus = "Розовый" });
                //db.UsersCards.Add(new UserCard { CardId = 8, DeckId = 1, UserId = 1, Translation = "Orange", Rus = "Оранжевый" });
                //db.UsersCards.Add(new UserCard { CardId = 9, DeckId = 1, UserId = 1, Translation = "Brown", Rus = "Коричневый" });
                //db.UsersCards.Add(new UserCard { CardId = 0, DeckId = 1, UserId = 1, Translation = "Gray", Rus = "Серый" });
                //db.SaveChanges();

                //db.UsersDecks.Add(new UserDeck { DeckId = 2, UserId = 1, Title = "Transport", Progress = 0, Size = 12 });
                //db.UsersCards.Add(new UserCard { CardId = 1, DeckId = 2, UserId = 1, Translation = "Car", Rus = "Автомобиль" });
                //db.UsersCards.Add(new UserCard { CardId = 2, DeckId = 2, UserId = 1, Translation = "Bus", Rus = "Автобус" });
                //db.UsersCards.Add(new UserCard { CardId = 3, DeckId = 2, UserId = 1, Translation = "Airplane", Rus = "Самолёт" });
                //db.UsersCards.Add(new UserCard { CardId = 4, DeckId = 2, UserId = 1, Translation = "Truck", Rus = "Грузовик" });
                //db.UsersCards.Add(new UserCard { CardId = 5, DeckId = 2, UserId = 1, Translation = "Helicopter", Rus = "Вертолёт" });
                //db.UsersCards.Add(new UserCard { CardId = 6, DeckId = 2, UserId = 1, Translation = "Motorcycle", Rus = "Мотоцикл" });
                //db.UsersCards.Add(new UserCard { CardId = 7, DeckId = 2, UserId = 1, Translation = "Boat", Rus = "Лодка" });
                //db.UsersCards.Add(new UserCard { CardId = 8, DeckId = 2, UserId = 1, Translation = "Ship", Rus = "Корабль" });
                //db.UsersCards.Add(new UserCard { CardId = 9, DeckId = 2, UserId = 1, Translation = "Train", Rus = "Поезд" });
                //db.UsersCards.Add(new UserCard { CardId = 10, DeckId = 2, UserId = 1, Translation = "Scooter", Rus = "Скутер" });
                //db.UsersCards.Add(new UserCard { CardId = 11, DeckId = 2, UserId = 1, Translation = "Bicycle", Rus = "Велосипед" });
                //db.UsersCards.Add(new UserCard { CardId = 0, DeckId = 2, UserId = 1, Translation = "Van", Rus = "Фургон" });
                //db.SaveChanges();

                //db.UsersDecks.Add(new UserDeck { DeckId = 1, UserId = 2, Title = "Sport", Progress = 0, Size = 4 });
                //db.UsersCards.Add(new UserCard { CardId = 1, DeckId = 1, UserId = 2, Translation = "Football", Rus = "Футбол" });
                //db.UsersCards.Add(new UserCard { CardId = 2, DeckId = 1, UserId = 2, Translation = "Swimming", Rus = "Плавание" });
                //db.UsersCards.Add(new UserCard { CardId = 3, DeckId = 1, UserId = 2, Translation = "Box", Rus = "Бокс" });
                //db.UsersCards.Add(new UserCard { CardId = 0, DeckId = 1, UserId = 2, Translation = "Kybersport", Rus = "Киберспорт" });
                //db.SaveChanges();

                //db.UsersDecks.Add(new UserDeck { DeckId = 1, UserId = 3, Title = "Letters", Progress = 0, Size = 4 });
                //db.UsersCards.Add(new UserCard { CardId = 1, DeckId = 1, UserId = 3, Translation = "a", Rus = "а" });
                //db.UsersCards.Add(new UserCard { CardId = 2, DeckId = 1, UserId = 3, Translation = "b", Rus = "б" });
                //db.UsersCards.Add(new UserCard { CardId = 3, DeckId = 1, UserId = 3, Translation = "c", Rus = "ц" });
                //db.UsersCards.Add(new UserCard { CardId = 0, DeckId = 1, UserId = 3, Translation = "d", Rus = "д" });
                //db.SaveChanges();
            }
        }

        [HttpGet]
        public JsonResult GetAllBasicDecks()
        {
            return new JsonResult("Database initialized!");
        }

    }
}
