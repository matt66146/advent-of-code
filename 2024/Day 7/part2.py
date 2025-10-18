#slow ugly version
import time



calibration_result = 0
data = None
current_problem = 1

with open("input.txt") as input_file:
    data = input_file.read().splitlines()

start = time.time()
current_line = 0
for line in data:
    print(str(current_line) + " / "+str(len(data)))
    current_line +=1
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
    initial_length = len(problems)

    """
    + + +
    + + *
    + * +
    + * *
    * + +
    * + *
    * * +
    * * *
    """

    for i in range(0,initial_length):
        #print("     "+str(i)+" / " + str(initial_length))
        #(6 + 8 + 6 + 15)

        for j in range(1,num_solution):
            problem = problems[i].copy()
            text = format(j, '0{}b'.format(num_symbols))
            # 0 0 0
            for k in range(0,len(text)):
                if text[k] == "1":
                    problem[(k*2)+1] = "||"
                    
                    
            
                problems.append(problem)
        
            
  
            



    #for problem in problems:
        #print(problem)


    
    for problem in problems:
        potential_answer = problem[0]
        for i in range(1,len(problem),2):
            if problem[i] == "+":
                potential_answer = potential_answer + problem[i+1]
            elif problem[i] == "*":
                potential_answer = potential_answer * problem[i+1]
            else:
                potential_answer = int(str(potential_answer) + str(problem[i+1]))
        if potential_answer == answer:
            solution_found = True
            break

    if solution_found:
        #print(answer)
        calibration_result += answer
    

end = time.time()

print("Result: "+str(calibration_result))
print(end-start)

