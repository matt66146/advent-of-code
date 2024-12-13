
input = None
num_cols = None

score_total = 0

score_indexes = []


def Navigate(index,num_cols,input,start):
    global score_total
    # Check left
    if (index % num_cols) - 1 >=0:
        if int(input[index-1]) == int(input[index])+1:
            if input[index-1] == "9":
                score_indexes[start].append(index-1)
            else:
                Navigate(index-1,num_cols,input,start)
        
    # Check right
    if (index % num_cols)+1 < num_cols:
        if int(input[index+1]) == int(input[index])+1:
            if input[index+1] == "9":
                score_indexes[start].append(index+1)
            else:
                Navigate(index+1,num_cols,input,start)
    # Check up
    if index-num_cols >=0:
        if int(input[index-num_cols]) == int(input[index])+1:
            if input[index-num_cols] == "9":
                score_indexes[start].append(index-num_cols)
            else:
                Navigate(index-num_cols,num_cols,input,start)
    # Check down
    if index+num_cols < len(input):
        if int(input[index+num_cols]) == int(input[index])+1:
            if input[index+num_cols] == "9":
                score_indexes[start].append(index+num_cols)
            else:
                Navigate(index+num_cols,num_cols,input,start)

with open("input.txt") as input_file:
    input = input_file.read().replace("\n","")


with open("input.txt") as input_file:
    num_cols = len(input_file.readlines()[0].replace("\n",""))


current_zero = -1
for i in range(0,len(input)):
    score_indexes.append([])
    if input[i] == "0":
        current_zero += 1
        Navigate(i,num_cols,input,i)




print(num_cols)
print(score_total)

for i in range(0,len(score_indexes)):
    #score_indexes[i] = list(set(score_indexes[i]))
    for peak in score_indexes[i]:
        score_total += 1


temp = [x for x in score_indexes if x != []]
score_indexes = temp





for i in range (0,len(score_indexes)):
    for j in range(0,len(score_indexes[i])):
        s = score_indexes[i][j]
        score_indexes[i][j] = (s%num_cols, s//num_cols)

print(score_total)
print(score_indexes)