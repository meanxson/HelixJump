using System;
using System.Collections;
using System.Collections.Generic;
using Ball;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 directionOffset;
    [SerializeField] private float lenght;
    
    private Ball.Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball.Ball>();
        _beam = FindObjectOfType<Beam>();

        var ballPosition = _ball.transform.position;
        _cameraPosition = ballPosition;
        _minimumBallPosition = ballPosition;
        
        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        var beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        var ballTransform = _ball.transform;
        var ballPosition = ballTransform.position;
        _cameraPosition = ballPosition;
        Vector3 direction = (beamPosition - ballPosition).normalized;
        _cameraPosition -= direction * lenght;
        transform.position = _cameraPosition;
        transform.LookAt(ballTransform);
    }
}
