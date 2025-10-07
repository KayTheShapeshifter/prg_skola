
import random
rnd = random.randint(1,9)

inputFunction1 = rnd*2 + 1
print("width =", inputFunction1)

def funkce_1(width):
    if width % 2 == 0 or width < 3 or width > 20:
        return 1
    else:
        for i in range(width):
            if i == 0 or i == width - 1:
                print("$", end="")
                for j in range(width-2):
                    print("-", end="")
                print("$")
            elif i < width / 2:
                print(" "*i, end="")
                for j in range(width - 2*i):
                    print("x", end="")
                print(" "*i)
            else:
                print(" "*(width - i - 1), end="")
                for j in range(width - 2*(width - i - 1)):
                    print("x", end="")
                print(" "*(width - i - 1))
        return 0

def funkce_2(width, middleHeight):
    if width % 2 == 0 or width < 3 or width > 20:
        return 1
    elif middleHeight >= width:
        return 2
    else:
        for i in range(width + middleHeight):
            if i == 0 or i == width + middleHeight - 1:
                print(" "*int((width/2)), end="")
                print("o", end="")
                print(" "*int((width/2)))

            elif i < width / 2:
                print(" "*int((width/2)-i), end="")
                for j in range(1+2*i):
                    print("@", end="")
                print(" "*int((width/2)-i))
            elif i < width / 2 + middleHeight - 1:
                print("@",end="")
                print("x"*(width-2), end="")
                print("@")
            else:
                print(" " * int((width / 2) - (width + middleHeight - 1 - i)), end="")
                for j in range(1 + 2 * (width + middleHeight - 1 - i)):
                    print("@", end="")
                print(" " * int((width / 2) - (width + middleHeight - 1 - i)))

        return 0
    
    

funkce_1(inputFunction1)
funkce_2(inputFunction1, inputFunction1 - rnd)