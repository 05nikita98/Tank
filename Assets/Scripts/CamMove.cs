using UnityEngine;

public class CamMove : MonoBehaviour
{

	// Устанавливаем скорость вращение по горзонтали
	// и скорость вращения по вертикале
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	// В эти переменные можете установить изначальные отступы для камеры
	private float hOffset = 0.0f; // Отступ по горизонтали
	private float vOffset = 0.0f; // Отступ по вертикали

	void Update()
	{
		// Здесь отслеживаем вращение мыши и умножаем его на скорость

		// Вы можете заметить что мы переменные расставили наоборот
		// сначала vOffset, а потом hOffset
		// Тут ничего не напутано, просто через GetAxis("Mouse X")
		// мы получим как раз вращение по координате Y для камеры, 
		// как бы странно это не звучало
		vOffset += speedH * Input.GetAxis("Mouse X");
		hOffset -= speedV * Input.GetAxis("Mouse Y");

		// Здесь постоянно указываем новые координаты вращения для камеры
		transform.eulerAngles = new Vector3(hOffset, vOffset, 0.0f);
	}

}