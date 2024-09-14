using System;

namespace FacadePattern
{
    internal static class ShapeDrawer
    {
        public static void DrawRect(uint positionX, uint positionY, int width, int height, ConsoleColor color = ConsoleColor.Gray, bool isFilled = false)
        {
            int posX = (int)positionX;
            int posY = (int)positionY;
            Console.ForegroundColor = color;

            for (int i = 0; i < height; i++)
            {
                if (!IsWithinConsoleBounds(posX, posY))
                {
                    ResetConsole();
                    return;
                }
                Console.SetCursorPosition(posX, posY);
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1)
                    {
                        Console.Write('─');
                    }
                    else
                    {
                        if (j == 0 || j == width - 1)
                        {
                            Console.Write('|');
                        }
                        else
                        {
                            Console.Write(isFilled ? '█' : ' ');
                        }
                    }
                }
                posY++;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DrawCircle(uint positionX, uint positionY, int radius, ConsoleColor color = ConsoleColor.Gray, bool isFilled = false)
        {
            int posX = (int)positionX;
            int posY = (int)positionY;
            Console.ForegroundColor = color;

            for (int y = -radius; y <= radius; y++)
            {
                if (!IsWithinConsoleBounds(posX, posY))
                {
                    ResetConsole();
                    return;
                }
                Console.SetCursorPosition(posX, posY);
                for (int x = -radius; x <= radius; x++)
                {
                    double distance = Math.Sqrt((x * x) + (y * y));

                    if (isFilled)
                    {
                        if (distance <= radius)
                            Console.Write('█');
                        else
                            Console.Write(' ');
                    }
                    else
                    {
                        if (distance >= radius - 0.5 && distance <= radius + 0.5)
                            Console.Write('*');
                        else
                            Console.Write(' ');
                        Console.Write(' ');
                    }
                }
                posY++;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static bool IsWithinConsoleBounds(int x, int y)
        {
            return x >= 0 && x < Console.BufferWidth && y >= 0 && y < Console.BufferHeight;
        }

        private static void ResetConsole()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Console has been reset. Size of shape was too big for console buffer.");
        }
    }
}
