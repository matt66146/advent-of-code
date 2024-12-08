#slow ugly version
import time



calibration_result = 0
data = None
current_problem = 1

with open("input.txt") as input_file:
    data = input_file.read().splitlines()

start = time.time()
for line in data:
    #print(str(current_problem) + " / " + str(len(data)))
    current_problem +=1
    line_data =  line.split(" ")
    num_symbols = len(line_data)-2

    num_solution = 2**num_symbols


    answer = int(line_data[0][:-1])
    nums = []
    for num in range(1,len(line_data)):
        nums.append(int(line_data[num]))
    
    problems = []

    solution_found = False


    for i in range(0,num_solution):
        text = format(i, '0{}b'.format(num_symbols))
        problem = []
        for j in range(0,len(text)):
            problem.append(nums[j])
            if text[j] == "0":
                problem.append("+")
            else:
                problem.append("*")
        problem.append(nums[-1])
        problems.append(problem)
    #print(problems)


    for problem in problems:
        potential_answer = problem[0]
        for i in range(1,len(problem),2):
            if problem[i] == "+":
                potential_answer = potential_answer + problem[i+1]
            else:
                potential_answer = potential_answer * problem[i+1]
        
        if potential_answer == answer:
            solution_found = True
            break

    if solution_found:
        calibration_result += answer

end = time.time()
print(calibration_result)
print(end-start)