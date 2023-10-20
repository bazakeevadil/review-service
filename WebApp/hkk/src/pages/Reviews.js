import React from 'react'
import { useParams } from 'react-router'

const Reviews = () => {
    const { id } = useParams()
    console.log(id);
    return (
        <div>
            <div className="comments">
                <div className="container">
                    <div className='comments__box'>
                        <div className='comments__leftSide'>
                        <p className="comments__title">
                            Java Script
                        </p>
                        <div className="comments__img">
                            <img src="https://itproger.com/img/courses/1476977754.jpg" alt="" />
                        </div>
                        </div>
                        <div className="addition">

                            <div className="addition__wrapper">
                                <p className="addition__title">
                                    Добавить новый отзыв
                                </p>

                                <textarea className="addition__form" name="" id="" rows="10"></textarea>
                                <button className="addition__btn"> Опубликовать</button>
                            </div>

                        </div>
                    </div>
                    <div className="comments__wrapper">
                     
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                        <div className="comments__card">
                            <div className="comments__text">
                                Lorem, ipsum dolor sit amet consectetur adipisicing elit. Consectetur repellat eos recusandae beatae cumque laudantium, distinctio sunt? Sed eligendi asperiores sint mollitia, necessitatibus aliquam nulla possimus commodi, eaque non voluptas?
                            </div>
                            <p className="comments__user">
                                kikiki lololo
                            </p>
                            <p className="comments__date">12.12.1212</p>
                            <p className="comments__rating">
                                ✭✭✭
                            </p>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    )
}

export default Reviews