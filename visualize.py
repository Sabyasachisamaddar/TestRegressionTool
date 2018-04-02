import matplotlib.pyplot as plt
import numpy as np
import itertools

with open("marks.txt") as f:
    data = f.read()

data = data.split('\n')
item, x ,y, z = [],[],[], []
for value in data:
    eachItem = value.split('\t')
    item.append(eachItem)
item.remove(item[-1])
item.remove(item[-1])

for i in item:
    x.append(i[1])
    y.append(i[2])
    z.append(i[3])

#data = data.split('\t')
#print(x, y)

x = list(map(int, x))
y = list(map(int, y))
z = list(map(int, z))
lists = sorted(zip(*[x, y, z]))
new_x, new_y, new_z = list(zip(*lists))



#new_x, new_y = zip(*sorted(zip(x, y)))
#print(new_x, new_y)

#new_x = list(map(int, new_x))
#new_y = list(map(int, new_y))
#new_z = list(map(int, new_z))

#new_x = [17, 30, 35, 37, 66, 70, 74, 96, 98, 98]
#new_y = [0, 50, 69, 0, 0, 95, 0, 0, 31, 76]

plt.plot(new_x,new_y, '*')
#plt.plot(new_x,new_z, '+')
plt.plot(new_x,new_z, '--')
print(new_x, new_z)
plt.show()






