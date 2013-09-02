FST SAMPLE OF 15 SECONDS IN 5 SECOND BINS (A,B,C and T for Total time)
S: Swimming
C: Climbing
F: Floating

Run:
S 0
C 2.1
S 3.3
F 5.2
S 7.5
F 11.3
S 12.5
F 13.3
C 14.7

	
Expected Results:
A-S	A-C	A-F		B-S	B-C	B-F		C-S	C-C	C-F		T-S	T-C	T-F
3.8	1.2	0.0		2.7	0.0	2.3		2.1	0.3	2.6		8.6	1.5	4.9


Calculations
A-S 2.1+1.7
B-S 0.2+2.5
C-S 1.3+0.8
C-F 1.2+1.4

T-S: 2.1+1.9+3.8+0.8=8.6
T-C: 1.2+0.3=1.5
T-F: 2.3+1.2+1.4=4.9



construct bins
## Pseudo Code
A:
start:0
end: 5
B: 
start: 5
end: 10
C:
start:10
end: 15


set bin=[A,B,C]
set i the index of the bin

while true
	if behavior.end < bin[i].end
		bin[i][behavior]+=behavior.duration
		behavior = behavior.next();
		if behavior is null
			break;
		continue;
	else
		bin[i][behavior]+=bin[i].end - behaviorstartinbin(behavior, i)
		set i++;
		if i is out of range
			break;
		continue;
		
def behaviorstartinbin (behavior, binindex) = 
	if binindex == 0 //in first bin return behavior start 
		return behavior.start
	if behavior.start > bin[binindex].start // if behavior started in this bin return behavior.start 
		return behavior.start
	else // if behavior started in previous bin return bin's start
		return bin[binindex].start

		

<EOF>		
// first attempt with foreach. issue with recursion on behaviors spreading on multiple time bins
foreach behavior
	if behavior.end < bin[i].end
		bin[i][behavior]+=behavior.duration
	else
		bin[i][behavior]+=bin[i].end - behaviorstartinbin(behavior, i)
		set i++;
		if behavior.end < bin[i].end
			bin[i][behavior]+=behavior.duration
		else
			bin[i][behavior]+=bin[i].end-behavior.start
