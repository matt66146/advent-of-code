
my_data = None
tj_data = None

with open("my_data.txt") as input_file:
    my_data = input_file.read().strip().split(",")

with open("tj_data.txt") as input_file:
    tj_data = input_file.read().strip().split(",")

print("Data Size: {}".format(len(my_data)))
print("Indices that don't match:")
for i in range (0,len(my_data)):
    if my_data[i] != tj_data[i]:
        print("{}: {}".format(i,my_data[i]))
print("--------------")
for i in range (0,len(my_data)):
    if my_data[i] != tj_data[i]:
        print("{}: {}".format(i,tj_data[i]))
        