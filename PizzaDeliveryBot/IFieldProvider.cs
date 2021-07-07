using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaDeliveryBot
{
    interface IFieldProvider
    {
        IField GetField();
    }
}
