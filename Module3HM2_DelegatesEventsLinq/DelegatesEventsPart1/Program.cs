using DelegatesEventsPart1;

ClassResult class2 = new ClassResult();
ClassResult.ResultDel resultDelegate = class2.Calc(ClassShow.Multiply, 3, 5);
bool resultValue = resultDelegate(5);

ClassShow.Show show = Show;
show(resultValue);

void Show(bool result)
{
    Console.WriteLine(result);
}