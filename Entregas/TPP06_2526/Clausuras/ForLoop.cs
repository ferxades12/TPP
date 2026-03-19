namespace Clausuras;

public class Clausuras
{
    /* static void Main(){
        int i = -10;
        ForLoop(() => i = 0, () => i < 10, () => i = i + 1, () => Console.WriteLine(i));
    } */

    public static void ForLoop(Action init, Func<bool> condition, Action iteration, Action body){
        init();
        innerLoop();

        void innerLoop(){
            if(condition()){
                body();
                iteration();
                innerLoop();
            }
        }
    }
}
