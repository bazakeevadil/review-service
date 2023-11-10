import React from 'react'
import { getCourses } from '../redux/action'
import { useDispatch, useSelector } from 'react-redux'
import { useEffect } from 'react'

const Home = () => {
    const img = ['https://i.pinimg.com/564x/ec/87/b6/ec87b60354654716445332f85ae73796.jpg', 'https://i.pinimg.com/564x/86/ad/01/86ad01aac334ed269e9d33dab95a2217.jpg', 'https://i.pinimg.com/564x/af/1f/b4/af1fb4e8700c6aa2c5b8d3e915eb6e99.jpg', 'https://i.pinimg.com/564x/0e/4f/dc/0e4fdce8ac22e09688c580e5bc4dcd7d.jpg', 'https://i.pinimg.com/564x/34/01/ee/3401ee2dbb27776d850e77c6a2bee3d2.jpg']
    const dispatch = useDispatch()
    const courses = useSelector(state => state.courses)
    useEffect(() => {
        dispatch(getCourses())
    }, [])
    return (
        <div>
            <div className="main">
                <div className="container">
                    <div className="main__wrapper">
                        <div className="main__img">
                            <img src="https://static.tildacdn.com/tild6137-3639-4364-a233-316662356666/Asset_7logo.png" alt="" />
                        </div>
                        <p className="main__title"> IT ACADEMY</p>
                        <p className="main__desc"> Стань программистом менее чем за год. Уникальная технология обучения не имеющая аналогов в СНГ.</p>
                    </div>
                </div>
            </div>

            <div className="card">
                <div className="container">
                    <div className="card__wrapper">
                        {courses.map((el, i) => (


                            <div className='card__card'>
                                <div className='card__img'>
                                    <img src={img[i]} />
                                </div>
                                <p className='card__title'>
                                    {el.name}
                                </p>
                                <p className='card__desc'>
                                    {el.description}
                                </p>
                                <button className="card__btn">
                                    Узнать больше
                                </button>
                            </div>
                        ))}

                    </div>
                </div>
            </div>
            <div className="review">
                <div className="container">
                    <p className="review__title">Отзывы</p>
                    <div className="review__wrapper">
                        <div className="review__card">
                            <p className="review__symbol">“</p>
                            <p className="review__text">
                                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam dolorem molestias dolor ipsa sit eum quisquam, esse explicabo id commodi alias assumenda veniam vero, sunt aliquid similique porro laboriosam. Dolore.
                            </p>
                            <p className="review__user">
                                Kfdhjfdhf jdfdjbf
                            </p>
                            <p className="review__group">
                                Frontend
                            </p>
                        </div>
                        <div className="review__card">
                            <p className="review__symbol">“</p>
                            <p className="review__text">
                                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam dolorem molestias dolor ipsa sit eum quisquam, esse explicabo id commodi alias assumenda veniam vero, sunt aliquid similique porro laboriosam. Dolore.
                            </p>
                            <p className="review__user">
                                Kfdhjfdhf jdfdjbf
                            </p>
                            <p className="review__group">
                                Frontend
                            </p>
                        </div>
                        <div className="review__card">
                            <p className="review__symbol">“</p>
                            <p className="review__text">
                                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam dolorem molestias dolor ipsa sit eum quisquam, esse explicabo id commodi alias assumenda veniam vero, sunt aliquid similique porro laboriosam. Dolore.
                            </p>
                            <p className="review__user">
                                Kfdhjfdhf jdfdjbf
                            </p>
                            <p className="review__group">
                                Frontend
                            </p>
                        </div>
                        <div className="review__card">
                            <p className="review__symbol">“</p>
                            <p className="review__text">
                                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Numquam dolorem molestias dolor ipsa sit eum quisquam, esse explicabo id commodi alias assumenda veniam vero, sunt aliquid similique porro laboriosam. Dolore.
                            </p>
                            <p className="review__user">
                                Kfdhjfdhf jdfdjbf
                            </p>
                            <p className="review__group">
                                Frontend
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    )
}

export default Home