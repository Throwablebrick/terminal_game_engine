import os

class Terminal:
    def __init__(self, width, height):
        self.__terminal_size = os.get_terminal_size()
        self.__prev_terminal_size = self.__terminal_size

        self.Width = width
        self.Height = height
        self.Start_x = (self.__terminal_size.columns - self.Width) / 2 + 1
        self.Start_y = (self.__terminal_size.lines - self.Height) / 2 + 1

        self.border_color = "\x1b[38;5;15m\x1b[48;5;70m"
        self.background_color = "\x1b[38;5;16m\x1b[48;5;16m"
        self.screen_color = "\033[0m"

        self.background_char = '#'
        self.border_side_char = '|'
        self.border_horizontal_char = '-'
        self.screen_char = ' '

        self.corner_top_left = '┌'
        self.corner_top_right = '┐'
        self.corner_bottom_left = '└'
        self.corner_bottom_right = '┘'

    def Update(self):
        self.__prev_terminal_size = self.__terminal_size
        self.__terminal_size = os.get_terminal_size()
        if self.__prev_terminal_size != self.__terminal_size:
            self.DrawBorder()

    def DrawBorder(self):
        print("\033[H",end='')
        if self.__terminal_size.columns < self.Width or self.__terminal_size.lines < self.Height:
            print("console too small")
        else:
            diff_x = self.__terminal_size.columns - self.Width
            diff_y = self.__terminal_size.lines - self.Height

            top_margin = diff_y // 2
            Start_y = top_margin + 1
            bottom_margin = diff_y - top_margin
            bottom_margin = self.__terminal_size.lines - bottom_margin
            top_margin -= 1

            left_margin = diff_x // 2
            Start_x = left_margin + 1
            right_margin = diff_x - left_margin
            right_margin = self.__terminal_size.columns - right_margin
            left_margin -= 1

            #print(f"width {self.__terminal_size.columns}, height {self.__terminal_size.lines}")
            #print(f"top {top_margin}, bottom {bottom_margin}")
            #print(f"left {left_margin}, right {right_margin}")

            for i in range(self.__terminal_size.lines):
                for n in range(self.__terminal_size.columns):
                    if i < top_margin or i > bottom_margin:
                        if n == 0:
                            print(f"{self.background_color}{self.background_char}",end="")
                        elif n == self.__terminal_size.columns - 1:
                            if i != self.__terminal_size.lines - 1:
                                print(f"{self.background_char}")
                            else:
                                print(f"{self.background_char}",end="")
                        else:
                            print(f"{self.background_char}",end="")
                    elif i == top_margin or i == bottom_margin:
                        if n < left_margin or n > right_margin:
                            if n == 0:
                                print(f"{self.background_color}{self.background_char}",end="")
                            elif n == self.__terminal_size.columns - 1:
                                print(f"{self.background_char}")
                            else:
                                print(f"{self.background_char}",end="")
                        elif n == left_margin:
                            if i == top_margin:
                                print(f"{self.border_color}{self.corner_top_left}",end="")
                            else:
                                print(f"{self.border_color}{self.corner_bottom_left}",end="")
                        elif n == right_margin:
                            if i == top_margin:
                                print(f"{self.corner_top_right}{self.background_color}",end="")
                            else:
                                print(f"{self.corner_bottom_right}{self.background_color}",end="")
                        else:
                            print(f"{self.border_horizontal_char}",end="")
                    else:
                        if n < left_margin or n > right_margin:
                            if n == 0:
                                print(f"{self.background_color}{self.background_char}",end="")
                            elif n == self.__terminal_size.columns:
                                print(f"{self.background_char}")
                            else:
                                print(f"{self.background_char}",end="")
                        elif n == left_margin or n == right_margin:
                            print(f"{self.border_color}|{self.background_color}",end="")
                        elif n == left_margin + 1:
                            print(f"{self.screen_color}{self.screen_char}",end="")
                        else:
                            print(f"{self.screen_char}",end="")
