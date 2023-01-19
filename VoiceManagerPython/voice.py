import pyttsx3, pyfiglet

ascii_banner = pyfiglet.figlet_format("By Zyxal")
print(ascii_banner)

print('Я создан -> Zyxal')
print( )
print('Мой контакты -> https://github.com/Zyxal-dev')
print( )

text1 = 'Здраствуйте, Admin Zyxal!'
text2 = 'Сегодня можно трейдить на Биткоине!'
text3 = 'Делаю анализ на завтра, по Эфириуме...'
text4 = '73% прибыль!'
text5 = 'Анализ прошёл успешно сможете завтра трейдить на Эфириуме!'
tts = pyttsx3.init()
rate = tts.getProperty('rate') #Скорость произношения
tts.setProperty('rate', rate-40)

volume = tts.getProperty('volume') #Громкость голоса
tts.setProperty('volume', volume+0.9)

voices = tts.getProperty('voices')

# Задать голос по умолчанию
tts.setProperty('voice', 'ru') 

# Попробовать установить предпочтительный голос
for voice in voices:
    if voice.name == 'Vitaliy':
        tts.setProperty('voice', voice.id)

tts.say(text1)
tts.say(text2)
tts.say(text3)
tts.say(text4)
tts.say(text5)
tts.runAndWait()