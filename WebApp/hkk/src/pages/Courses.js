import React from 'react'
import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'
const Courses = () => {
    const courses = useSelector(state => state.courses)
    const img = ['https://i.pinimg.com/564x/ec/87/b6/ec87b60354654716445332f85ae73796.jpg','https://i.pinimg.com/564x/86/ad/01/86ad01aac334ed269e9d33dab95a2217.jpg','https://i.pinimg.com/564x/af/1f/b4/af1fb4e8700c6aa2c5b8d3e915eb6e99.jpg','https://i.pinimg.com/564x/0e/4f/dc/0e4fdce8ac22e09688c580e5bc4dcd7d.jpg','https://i.pinimg.com/564x/34/01/ee/3401ee2dbb27776d850e77c6a2bee3d2.jpg']
console.log(courses);
  return (
    <div className="courses">
        <div className="container">
            <h1 className="courses__title">Курсы</h1>
            <div className="courses__wrapper">
            { 
            courses.map((el,i)=>(

          
               <div className="courses__card">
                <div className="courses__img">
                    <img src={img[i]}/>
                </div>
                <p className="courses__info">
                 {el.name}
                </p>
                <p className="courses__rating">
                    ✭✭✭✭✭
                </p>
                <p className="courses__reviews">
                    120 отзывов
                </p>
               <Link to={`/courses/${el.id}`}>
                <button className='courses__btn'>
                    перейти
                    </button>
                </Link>
               </div>
                 )) }
              
            </div>
        </div>
    </div>
  )
}

export default Courses