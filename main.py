import graphics.Terminal
import pygame
import keyboard
import datetime


pygame.init()
#screen = pygame.display.set_mode((1,1))
clock = pygame.time.Clock()

t = graphics.Terminal.Terminal(100,40)
print("\x1b[?251\x1b2J")
t.DrawBorder()
running = True

def on_key_press(event):
    running = False


while running:
    keyboard.on_press(on_key_press)
    #for event in pygame.event.get():
    #    if event.type == pygame.QUIT:
    #        running = False

    #keys = pygame.key.get_pressed()
    #if keys[pygame.K_q]:
    #    running = False
    t.Update()
    clock.tick(60)

pygame.quit()
