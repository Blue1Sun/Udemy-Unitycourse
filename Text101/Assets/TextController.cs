using UnityEngine;
using UnityEngine.UI; // for User Interface
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, window, bones, table, door, bad_end, end};
	private bool bottle, begin;
	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
		bottle = false;
		begin = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell)				state_cell();
		else if (myState == States.window)		state_window();
		else if (myState == States.bones)		state_bones();
		else if (myState == States.table)		state_table();
		else if (myState == States.door)		state_door();
		else if (myState == States.bad_end)		state_bad_end();
		else if (myState == States.end)			state_end();
	}
	
	#region states
	void state_cell (){
		string begining = "Ты проснулся один в холодном помещении темницы с каменными стенами. " +
				"Как ты вообще здесь оказался?\n\r";
		string cell = "Высоко сзади тебя находится окно с решеткой, рядом на полу валяется груда " +
				"костей предыдущего заключенного, погибшего прямо в кандалах, которые не потрудились " +
				"снять, у левой стены стоит деревянный покосившийся столик. " +
				"Впереди от свободы тебя отделяют толстые прутья решетки. " + 
				"Из камеры напротив слышится приглушенное бормотание." + 
				"\n\rНажмите Q для того чтобы осмотреть окно.\n\r" + 
				"Нажмите W для того чтобы осмотреть кости.\n\r" + 
				"Нажмите E для того чтобы осмотреть столик.\n\r" + 
				"Нажмите R для того чтобы подойти к решетке.\n\r";
		if (begin == true)		{text.text = begining + cell;}
		else 					{text.text = cell;}
		if (Input.GetKeyDown(KeyCode.Q)){
			myState = States.window;
			begin = false;
		}
		else if (Input.GetKeyDown(KeyCode.W)){
			myState = States.bones;
			begin = false;
		}
		else if (Input.GetKeyDown(KeyCode.E)){
			myState = States.table;
			begin = false;
		}
		else if (Input.GetKeyDown(KeyCode.R)){
			myState = States.door;
			begin = false;
		}
	}
	
	void state_window(){
		text.text = "Окно находится слишком высоко, и до него не достать, будь ты даже эльфом-переростком. " + 
				"Сбежать через него не получится, да и сквозь прутья никак не пролезешь. Надо искать другой путь" +
				"\n\rНажмите Q для того чтобы вернуться к осмотру камеры.\n\r";
		if (Input.GetKeyDown(KeyCode.Q))	{myState = States.cell;}
	}
	
	void state_bones(){
		text.text = "Печальное зрелище. Остается только надеяться и верить, " +
				"что тебя не постигнет та же голодная участь..." + 
				"\n\rНажмите Q для того чтобы вернуться к осмотру камеры.\n\r";
		if (Input.GetKeyDown(KeyCode.Q))	{myState = States.cell;}
	}	
	
	void state_table(){
		string table1 = "На столе нету ни крошки, что уж говорить о полноценной тарелке похлебки. " +
				"Кувшин тоже пуст и покрыт пылью и паутиной, но его можно использовать в качестве оружия." +
				"\n\rНажмите Q для того чтобы вернуться к осмотру камеры.\n\r";
		string bottlet = "Нажмите W для того чтобы взять кувшин с собой.\n\r";
		string table2 = "На столе нету ни крошки, что уж говорить о полноценной тарелке похлебки. " +
				"Без кувшина столик и вовсе смотрится жалко." +
				"\n\rНажмите Q для того чтобы вернуться к осмотру камеры.\n\r";
		if (bottle == false)	{text.text = table1 + bottlet;}
		else 					{text.text = table2;}

		if (Input.GetKeyDown(KeyCode.Q))	{myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.W) && bottle == false){
			myState = States.cell;
			bottle = true;
		}
	}
	
	void state_door(){
		string door = "Едва ты подходишь к решетке, как замечаешь напротив заключенного-эльфа, который тут же завязывает разговор.\n\r" +
				"- Посмотрите-ка, кто попался за решетку, как грустно. Конечно, никому не захочется гнить в темнице до конца своих дней, " +
				"но кому какое дело до твоих желаний... Ты подохнешь здесь, забытый всеми, даже тюремщиком! - на лестнице слышится шум. - " +
				"Эй, ты слышишь? Стражники идут... за тобой! Хе хе хе хе хе.\n\r" +  
				"По обрывкам разговора можно понять, что наследники престола убиты, а на короля, которого ты сейчас видишь перед собой, охотятся ассасины. " + 
				"Ты явно не должен был быть в этой камере, но видимо именно так сложились звезды. Тебе приказывают отойти к окну и не делать лишних движений." +   
				"\n\rНажмите Q для того чтобы не перечить и отойти к окну как велено.\n\r";
		string bottlet = "Нажмите W для того чтобы бросить кувшин в стражу.\n\r";
		if (bottle == true)		{text.text = door + bottlet;}
		else 					{text.text = door;}
		if (Input.GetKeyDown(KeyCode.Q))							{myState = States.end;}
		else if (Input.GetKeyDown(KeyCode.W) && bottle == true)		{myState = States.bad_end;}
	}
	
	void state_bad_end(){
		text.text = "Кажется, бросать кувшин было плохой идеей. О чем-то только думал? Впрочем, какая разница, " + 
				"тебе ведь и думать-то теперь нечем, после того как начальник стражи мгновенно и не задумываясь отрубил тебе " + 
				"голову своим клинком..." + 
				"\n\rНажми Q, чтобы начать игру заново. И постарайся не умереть!";
		if (Input.GetKeyDown(KeyCode.Q)){
			myState = States.cell;
			begin = true; 
			bottle = false;
		}
	}
	
	void state_end(){
		text.text = "Ты покорно отходишь к задней стене своей камеры под строгим взглядом одного из стражников. " + 
				"Он явно не доверяет тебе, но, наверное, это не удивительно, ведь ты попал в тюрьму не просто так. " + 
				"Ты же в свою очередь просто хочешь не быть убитым из-за какой-то глупости. Ты замечаешь, что сам король " + 
				"останавливается перед тобой и внимательно изучает взглядом.\n\r" + 
				"- Ты... Я видел тебя... - он определенно обращается именно к тебе. - Подойди ближе. Хочу тебя я видеть... - " + 
				"с нескрываемым удивлением ты выполняешь требование. - Именно тебя я видел во снах...\n\r\n\r" + 
				"\t\tto be continued...";
	}
	#endregion
}
