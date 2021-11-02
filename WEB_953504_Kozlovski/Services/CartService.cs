using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Entities;
using WEB_953504_Kozlovski.Extentions;
using WEB_953504_Kozlovski.Models;

namespace WEB_953504_Kozlovski.Services
{
    public class CartService : Cart
    {
        private string sessionKey = "cart";
        /// <summary>
        /// Объект сессии
        /// Не записывается в сессию вместе с CartService
        /// </summary>
        [JsonIgnore]
        ISession Session { get; set; }

        /// <summary>
        /// Получение объекта класса CartService
        /// </summary>
        /// <param name="sp">объект IserviceProvider</param>
        /// <returns>объекта класса CartService, приведенный к типу Cart</returns>
        public static Cart GetCart(IServiceProvider sp)
        {
            // получить объект сессии
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            
            // получить CartService из сессии
            // или создать новый для возможности тестирования
            var cart = session?.Get<CartService>("cart") ?? new CartService();

            cart.Session = session;
            return cart;
        }

        // переопределение методов класса Cart
        // для сохранения результатов в сессии
        public override void AddToCart(Notebook notebook)
        {
            base.AddToCart(notebook);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }

        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
