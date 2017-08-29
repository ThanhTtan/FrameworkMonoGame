﻿using Framework.Generality.InputControl;
using Framework.Generality.OffSets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;


namespace Framework.Generality.Bases.Camera2D
{
    public class Camera
    {
        private int _viewportWidth;
        private int _viewportHeight;
        private bool _follow;
        private Vector2 _followPos;
        private float _zoom;
        private float _rotation;


        public Camera()
        {
            _viewportWidth = Constants.VIEWPORT_WIDTH;
            _viewportHeight = Constants.VIEWPORT_HEIGHT;
            _follow = false;
            _zoom = 1.0f;
            _rotation = 0.0f;
            _followPos = Vector2.Zero;
        }

        public void Update(float deltaTime,Vector2 follow)
        {
            _followPos = follow;      
        }

        public Matrix GetTransfromMatrix()
        {
            Matrix result = Matrix.Identity;
            result = Matrix.CreateTranslation(new Vector3(-_followPos, 0))
                * Matrix.CreateScale(_zoom)
                * Matrix.CreateRotationZ(_rotation)
                * Matrix.CreateTranslation(new Vector3(_viewportWidth/2,_viewportHeight/2, 0));
            return result;
        }
    }
}
