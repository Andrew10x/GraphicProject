# Реалізація рендерингу зображень методом трасування променів

На вхід приймається файл формату .obj. В результаті роботи програми отримуємо файл формату .ppm. Також є можливість виводити результат в консоль. В якості освітлення використовуєтсья flat shading. Для перетину променю з трикутником було використано алгоритм Моллера-Трумбора. Також були реалізовані матричні перетворення, які можна використовувати для об’єкту, що рендериться. 

## Опис методу трасування променів

Метод трасування променів полягає в наступному: кожна точка або вектор задається трьома координатами. Зазвичай, вектори використовуються замість точок у просторі як вектор між початком координат і точкою (координати вектора будуть тоді збігатися з координатами точки). Геометрія, яку треба візуалізувати, задається у вигляді набору трикутників у 3d просторі. Кожен трикутник — це набір з трьох точок/векторів у просторі. Камера, що "знімає" сцену, задається точкою в просторі та вектором напряму зйомки. Перед нею на невеликій відстані розташований уявний екран, що розділений на пікселі, кожен з якиї відповідає пікселю у вихідному зображенні. Із камери в бік сцени запускаються промені, кожен з яких проходить через піксель на екрані. Для кожного з цих променів програма обчислює, чи перетинає він будь-який з трикутників, що розташовані на сцені. Якщо таких трикутників немає, то піксель фарбується в колір фону. Інакше піксель фарбується іншим кольором. При цьому враховується кут падіння променю, тіні, глобальне освітлення.

## Приклад

Результат рендерингу корови, сфери та площини з тінями зображено нижче (зображення 400*400px):


![Result image](https://github.com/Andrew10x/GraphicProject/blob/master/res.jpg)
