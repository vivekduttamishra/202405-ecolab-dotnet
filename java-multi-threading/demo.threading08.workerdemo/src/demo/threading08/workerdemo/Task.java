package demo.threading08.workerdemo;

public interface Task<T> {

	void execute(T value);

}
