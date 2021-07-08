# PizzaDeliveryBot

## Описание

Основной проект `PizzaDeliveryBot` является консольным приложением, проект `UnitTests` содержит тесты NUnit. Класс `OptimalPathFinder` (используется по умолчанию) находит оптимальный путь, вычисляя расстояние от текущей точки до ближайших. Класс `SimplePathFinder` перебирает точки по порядку. Путь между двумя точками строится передвижением влево или вправо на N клеток, где N - разница расстояний по оси X между клетками, а затем по оси Y аналогичным способом.
Строка вводится в формате 
``` 
{ширина поля}x{высота поля} ({x1}, {y1}) ({x2}, {y2}) ... ({xn}, {yn}) 
```
Ширина и высота отделяются маленькой английской буквой x. Между определением высоты и первой точкой, а также между определениями точек строго 1 символ пробел. Определения координат точек заключаются в круглые скобки, координаты X и Y отделяются запятой и пробелом.

## Запуск

Открыть решение `PizzaDeliveryBot.sln`, собрать и запустить проект `PizzaDeliveryBot`.

**PS:** В прикрепленной к заданию строке для проверки решения `5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)` дважды встречается точка (4, 2). В задании данный случай не описан. Реализованный алгоритм работает так, что в данную точку необходимо доставить 2 пиццы. Также в описании точки (4,4) отсутствует пробел после запятой.