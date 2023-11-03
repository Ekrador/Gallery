# Gallery - практика Xamarin
### Задание написать собственную небольшую галерею для просмотра изображений на устройстве
** Техническое задание **
* Приложение должно содержать три экрана: экран PIN-кода, экран со списком изображений и экран просмотра конкретного изображения.
* Экран PIN-кода при первом запуске должен предлагать пользователю установить PIN-код из четырех символов. После первичной установки PIN-кода пользователю должен открываться экран со списком изображений.
* Если приложение запускается не первый раз, то экран PIN-кода должен запрашивать у пользователя установленный ранее PIN-код. После верного ввода PIN-кода пользователю должен открываться экран со списком изображений.
* Механизм хранения PIN-кода вы можете реализовать как хотите, но ключевое требование: PIN должен сохраняться при перезапуске приложения.
* Экран со списком изображений должен содержать галерею изображений (загруженных из папки Camera), точно так же, как содержит приложение Photos со скриншота выше. Но вдобавок к самим изображениям рядом с ними в списке должны также выводиться их имена. Стиль галереи (большие иконки или маленькие, горизонтальные или вертикальные, и т.д.) — на ваш выбор. 
* Внизу экрана со списком изображений должны быть две кнопки: «Открыть» и «Удалить».
* Кнопка «Открыть» должна открывать выбранное изображение во весь экран (отдельный экран просмотра конкретного изображения), и на этом экране рядом с фото должна стоять подпись, когда оно сделано.
* Кнопка «Удалить» должна удалять изображение из галереи и файловой системы устройства. При удалении пользователь не должен переходить на другую страницу, а страница со списком изображений (на которой он находится) должна автоматически убирать удаленное изображение из списка. 