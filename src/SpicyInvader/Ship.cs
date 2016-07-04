﻿//Lieu : ETML
//Date : 2016
//Auteur : JMY/CHA
//Description : Conteneur global du jeu

using System;

namespace SpicyInvader
{
    public class Ship
    {
        //Position du vaisseau sur l'axe horizontal (le zéro est tout à gauche de l'axe)
        private short xPosition;
        private readonly short rightLimit;
        private readonly short yPosition;

        //Dessin du vaisseau
        private const string SPRITE = "├¤┤";

        private FriendlyMissile missile;


        /// <summary>
        /// Création d'un vaisseau avec une position et une limite de déplacement
        /// </summary>
        /// <param name="initialXPosition"></param>
        /// <param name="rightLimit"></param>
        public Ship(int initialXPosition, int yPosition, int rightLimit)
        {
            this.xPosition = Convert.ToInt16(initialXPosition);
            this.rightLimit = Convert.ToInt16(rightLimit);
            this.yPosition = Convert.ToInt16(yPosition);
        }



        internal void setMissileDestroyed()
        {
            missile = null;
        }

        /// <summary>
        /// Lance un missile (si pas déjà un en cours)
        /// </summary>
        /// <returns>vrai si un nouveau missile a été lancé, faux s'il y en avait déjà un</returns>
        public bool fire()
        {
            if (missile == null)
            {
                missile = new FriendlyMissile(this, Convert.ToInt16(xPosition + SPRITE.Length / 2),
                                              Convert.ToInt16(yPosition - 1));

                missile.display();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Déplace le vaisseau sur la gauche (pour autant qu'il puisse encore)
        /// </summary>
        public void moveLeft()
        {
            if (xPosition > 0)
            {
                erase();
                xPosition--;
            }
            display();

        }

        /// <summary>
        /// Déplace le vaisseau sur la droite (jusqu'à rightLimit)
        /// </summary>
        public void moveRight()
        {
            if (xPosition < rightLimit - SPRITE.Length)
            {
                erase();
                xPosition++;
            }
            display();
        }

        public void erase()
        {
            Console.SetCursorPosition(Convert.ToInt32(xPosition), yPosition);
            Console.Write(new String(' ',getSprite().Length));
        }

        public void display()
        {
            Console.SetCursorPosition(Convert.ToInt32(xPosition), yPosition);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(getSprite());
        }

        //Accesseurs
        public string getSprite()
        {
            return SPRITE;
        }

        public bool isMissileFired()
        {
            return missile != null;
        }

        public FriendlyMissile getMissile()
        {
            return missile;
        }

        public short getXPosition()
        {
            return xPosition;
        }
    }
}
