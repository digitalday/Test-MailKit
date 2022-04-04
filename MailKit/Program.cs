using System;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Mail
{
    class program
    {
        
        public static void Main()
        {
            MimeMessage message = new MimeMessage();
            var bodyBuilderHTML = new BodyBuilder();


            Console.Write("почта получателя: ");
            string email = Console.ReadLine();

            if(email.Contains("@") || email.Contains("."))
            {

                message.From.Add(new MailboxAddress("Digital Days", "mailkittestcsharp@gmail.com")); //отправитель   // почта отправителя
                message.To.Add(MailboxAddress.Parse(email));//получатель
                message.ReplyTo.Add(new MailboxAddress("Support", "mailkittestcsharp@gmail.com")); // Загаловок отправителя при ответе на пмсьмо   // почта для ответа на письмо
                message.Subject = "Welcome!"; // тема 




                // отправка текста в формате HTML

                
                bodyBuilderHTML.HtmlBody = "<b>Test HTML TEXT</b>"; // пример текста
                message.Body = bodyBuilderHTML.ToMessageBody(); // передаем наш текст





                // создаем и подключаем smtp client
                SmtpClient smtp = new SmtpClient();
                try
                {
                    
                    smtp.Connect("smtp.gmail.com", 465, true); // Подключение    1)адресс smpt 2) порт 3) SSL подключение
                    smtp.Authenticate("mailkittestcsharp@gmail.com", password.Mailpass); // авторизация    1) почта 2) пароль от нее
                    smtp.Send(message); // отправка 
                    Console.WriteLine($"Сообщение было отправлено на адресс: {email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {

                    // Отключение клиента
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }

            } else
            {
                Console.WriteLine("Ошибка!");
            }

        }
    }
}
