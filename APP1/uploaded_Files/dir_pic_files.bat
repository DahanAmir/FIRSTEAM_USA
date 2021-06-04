cd\
cd %2
del pat_pics.txt
dir %1\*.* /B > pat_pics.txt
rem move pat_pics.txt %2
exit