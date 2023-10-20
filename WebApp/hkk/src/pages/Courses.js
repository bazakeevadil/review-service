import React from 'react'
import { Link } from 'react-router-dom'
const Courses = () => {
  return (
    <div className="courses">
        <div className="container">
            <h1 className="courses__title">Курсы</h1>
            <div className="courses__wrapper">
             
               <div className="courses__card">
                <div className="courses__img">
                    <img src="https://itproger.com/img/courses/1476977754.jpg" alt=""/>
                </div>
                <p className="courses__info">
                    Java script
                </p>
                <p className="courses__rating">
                    ✭✭✭✭✭
                </p>
                <p className="courses__reviews">
                    120 отзывов
                </p>
               <Link to={'/courses/1'}>
                <button className='courses__btn'>
                    перейти
                    </button>
                </Link>
               </div>
               <div className="courses__card">
                <div className="courses__img">
                    <img src="https://itproger.com/img/courses/1476977754.jpg" alt=""/>
                </div>
                <p className="courses__info">
                    Java script
                </p>
                <p className="courses__rating">
                    ✭✭✭✭✭
                </p>
                <p className="courses__reviews">
                    120 отзывов
                </p>
               </div>
               <div className="courses__card">
                <div className="courses__img">
                    <img src="https://itproger.com/img/courses/1476977754.jpg" alt=""/>
                </div>
                <p className="courses__info">
                    Java script
                </p>
                <p className="courses__rating">
                    ✭✭✭✭✭
                </p>
                <p className="courses__reviews">
                    120 отзывов
                </p>
               </div>
            </div>
        </div>
    </div>
  )
}

export default Courses