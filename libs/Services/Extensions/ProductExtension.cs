using System;
using System.Threading.Tasks;
using Core.Enums;
using Core.Exceptions;

namespace Services.Extensions
{
    public static class ProductExtension
    {
        public static async Task<bool> CanNotAddToOrder(this Color color, int userId, Func<Color, int, Task<bool>> hasOrderColorAsync)
        {
            switch (color)
            {
                case Color.Red:
                {
                    var canNotAdd = await hasOrderColorAsync(Color.Yellow, userId);
                    if (canNotAdd)
                    {
                        return true;
                    }

                    break;
                }
                case Color.Yellow:
                {
                    var canNotAdd = await hasOrderColorAsync(Color.Red, userId);
                    if (canNotAdd)
                    {
                        return true;
                    }

                    break;
                }
            }

            return false;
        }
    }
}