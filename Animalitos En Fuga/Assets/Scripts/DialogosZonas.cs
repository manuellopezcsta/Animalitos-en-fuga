using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosZonas : MonoBehaviour
{   
    string[] Dialogos = new string[] {
    "Bienvenidos al SuperDuper tenemos frutas, verduras y algunos animales",
    "Que linda casa para vacacionar, se la ve segura",
    "Y Rasho va por la banda, pasa al segundo, al primero.. pero... para... eso es... eso no es un caballo, esta es la mejor carrera que he vivido!!!",
    "Que buen sitio para sacar a pasear a las mascotas... mascotas?",
    "Esta es una de las mejores tiendas de la ciudad, por su gran variedad y seguridad",
    };

    public void DialogosZone(int index) { 
    GameManager.Instance.textBox.text = Dialogos[index];
    }
}
